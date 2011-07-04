
/// <reference path="JSchemaProvider.js" />

(function () {

    window.JSchemaProvider.CSharpVisitor = function () {
        this._lines = [];

    };
    window.JSchemaProvider.CSharpVisitor.prototype = {
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


    // private lib funcs

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
})();