/// <reference path="dto-schema.js" />
/// <reference path="JSchemaInheritanceResolver.js" />

// changes made to schema structure as implemented by current meta generation
//    extends - the use of $ref object in extends is based on an incorrect sample - correct use is simple string property


function test() {

    // for use when rendering the schema out flat
    var resolver = new JSchemaInheritanceResolver(schema);
    resolver.resolve();

    var visitor = new JSchemaProvider.Visitor();
    var provider = new JSchemaProvider(visitor);

    // FIXME: schema should be a ctor param 
    provider.schema = schema;
    // FIXME: instigator should not take parameters
    provider.visit("root", schema, "schema");



    var output = visitor.toString();
    // IE sucks
    output = output.replace(/\n/g, "<br/>").replace(/\s/g, "&nbsp;");
    document.getElementById("code").innerHTML = output;
};

(function () {

    var attributeNames = [
        "type",
        "extends",
        "properties",
        "patternProperties",
        "additionalProperties",
        "items",
        "additionalItems",
        "required",
        "dependencies",
        "minimum",
        "maximum",
        "exclusiveMinimum",
        "exclusiveMaximum",
        "minItems",
        "maxItems",
        "uniqueItems",
        "pattern",
        "minLength",
        "maxLength",
        "enum",
        "default",
        "title",
        "description",
        "format",
        "divisibleBy",
        "disallow",
        "id",
        "$ref",
        "$schema"];

    function isArray(obj) {
        return (obj && obj.prototype == Array);
    };

    function isDefined(obj) {
        return obj && (typeof (obj) != 'undefined');
    };

    function each(obj, action) {
        var self = this;
        if (obj.prototype && obj.prototype == Array) {
            for (var i = 0; i < obj.length; i++) {
                action.call(self, obj[i], i, obj);
            }
        }
        else if (typeof (obj) == "object") {
            for (var name in obj) {
                if (obj.hasOwnProperty(name)) {
                    action.call(self, obj[name], name, obj);
                };
            };
        }
        else {
            throw new Error("cannot iterate supplied obj");
        };
    };

    var provider = window.JSchemaProvider = function (visitor) {
        this.visitor = visitor;
        this.visitor.provider = this;
    };


    provider.prototype = {
        stack: [],
        visitor: {},

        push: function (key, value, type) {
            var current = { "key": key, "value": value, "type": type };
            this.stack.push(current);
        },
        pop: function () {
            this.stack.pop();
        },
        peek: function () {
            return this.stack[this.stack.length - 1];
        },
        visit: function (key, value, type) {


            var depth = this.stack.length;
            this.push(key, value, type);


            if (this.visitor["visit_" + type]) {
                this.visitor["visit_" + type]();
            };

            this["visit_" + type]();

            if (this.visitor["visit_" + type + "_end"]) {
                this.visitor["visit_" + type + "_end"]();
            };

            this.pop();
            if (depth != this.stack.length) {
                throw new Error("stack out of sync");
            }
        },

        "visit_schema": function () {

            var current = this.peek();
            // iterate all possible schema properties

            var self = this;
            each(attributeNames, function (value, key) {
                // todo: explosion of ambiguity here with 'value' - clarify
                if (isDefined(current.value[value])) {
                    self.visit(value, current.value[value], value);
                };
            });
        },
        "visit_properties": function () {
            // an obj array of property schema
            var current = this.peek();
            var self = this;
            each(current.value, function (value, key) {
                self.visit(key, value, "property");
            });
        },

        "visit_property": function () {
            // a property is a schema - this looks like duplicate code
            // and ultimately may be 

            var current = this.peek();
            // iterate all possible schema properties

            var self = this;
            each(attributeNames, function (value, key) {
                // todo: explosion of ambiguity here with 'value' - clarify
                if (isDefined(current.value[value])) {
                    self.visit(value, current.value[value], value);
                };
            });
        },

        "visit_type": function () {
            if (isArray()) {
                // is a union. array is populated
                // by simple type (string) and/or schema
                // this is how we specify nullable
            } else {
                // is a simple type
            };
        },
        "visit_disallow": function () {
            // similar to .type
        },
        "visit_extends": function () {
            // string or array of strings

        },


        "visit_patternProperties": function () { },
        "visit_additionalProperties": function () { },
        "visit_items": function () { },
        "visit_additionalItems": function () { },
        "visit_dependencies": function () { },
        "visit_enum": function () { },
        "visit_default": function () { },







        // simple props
        "visit_$ref": function () { },
        "visit_$schema": function () { },
        "visit_divisibleBy": function () { },
        "visit_pattern": function () { },
        "visit_minItems": function () { },
        "visit_maxItems": function () { },
        "visit_uniqueItems": function () { },
        "visit_minimum": function () { },
        "visit_maximum": function () { },
        "visit_exclusiveMinimum": function () { },
        "visit_exclusiveMaximum": function () { },
        "visit_required": function () { },
        "visit_description": function () { },
        "visit_id": function () { },
        "visit_format": function () { },
        "visit_title": function () { },
        "visit_minLength": function () { },
        "visit_maxLength": function () { }
    };






    provider.Visitor = function () {
        this._lines = [];



    };
    provider.Visitor.prototype = {
        provider: {},
        normalizeKey: function (key) {
            if (key.indexOf("#.") > -1 || key.indexOf("#/") > -1) {
                key = key.substring(2);
            };
            return key;
        },
        resolveType: function (property) {




            var propertyType;
            var nullable = false;
            var propIsArray = false;
            if (isArray(property.type)) {
                var self = this;

                // a nullable type will look like this
                // "type": ["null","integer"]

                var errMessage;
                // check for null

                if (property.type.length == 1 || property.type.length == 2) {


                    each(property.type, function (value) {
                        if (value == "null") { nullable = true; } else {
                            propertyType = value;
                        }
                    });
                }
                else {
                    errMessage = "only nullable union types implemented ('null' plus one simple type)";
                }

                if (errMessage) {
                    throw new Error(errMessage);
                };

            } else {
                propertyType = property.type;
            };


            if (property.$ref) {

                propertyType = this.normalizeKey(property.$ref);

            } else {
                switch (property.type) {
                    case "string":
                        // new formats "wcf-date"
                        if (property.format == "wcf-date") {
                            propertyType = "DateTime";
                        }
                        else {
                            propertyType = "string";
                        }
                        break;
                    case "number":
                        // new formats "decimal[-precision?]"
                        if (property.format == "decimal") {
                            propertyType = "decimal";
                        }
                        else {
                            propertyType = "float";
                        }
                        break;
                    case "integer":
                        propertyType = "int";
                        break;
                    case "boolean":
                        propertyType = "bool";
                        break;
                    case "object":
                        break;
                    case "array":

                        if (!isDefined(property.items)) {
                            throw new Error("items not specified for array type");
                        }
                        // only support homogenous arrays, so .items should have 1 element
                        break;
                    case "null":
                        break;
                    case "any":
                        break;
                }
            }




            return propertyType + (nullable ? "?" : "");

        },
        writeLine: function (value) {
            this._lines.push(value);
        },
        toString: function () {
            return this._lines.join("\n");
        },

        visit_schema: function () {


            switch (this.provider.stack.length) {
                case 1:
                    var namespace = this.provider.schema.namespace || "DefaultNamespace";
                    this.writeLine("namespace " + namespace);
                    this.writeLine("{");
                    break;
            }

        },
        visit_schema_end: function () {
            switch (this.provider.stack.length) {
                case 1:
                    this.writeLine("}");
                    break;
            }
        },

        visit_property: function () {
            var current = this.provider.peek();
            switch (this.provider.stack.length) {
                case 3: // type definition
                    var typeName = "class";
                    if (current.value["enum"]) {
                        typeName = "enum";
                    };
                    this.writeLine("    public " + typeName + " " + current.key + (current.value["extends"] ? (" : " + current.value["extends"]) : ""));
                    this.writeLine("    {");
                    break;
                case 5: // type property
                    var propertyType = this.resolveType(current.value);
                    this.writeLine("        public " + propertyType + " " + current.key + " { get; set; }");
                    break;
            }

        },

        visit_property_end: function () {
            switch (this.provider.stack.length) {
                case 3:
                    this.writeLine("    }");
                    break;
            }
        }

    };

})();





