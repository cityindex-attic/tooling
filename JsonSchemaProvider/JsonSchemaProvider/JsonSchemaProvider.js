var JsonSchemaProvider = function (writer) {
    /// <param name="writer" type="IJsonSchemaWriter"></param>
    this._writer = writer;

    // do some tedious code generation for visit _end methods
    var self = this;
    for (var i = 0; i < this.attributeNames.length; i++) {
        var property = this.attributeNames[i];
        this["visit_" + property + "_end"] = (function (member) {
            return function (key, current, stack) {
                self._executeAndPopStack(key, self._writer["visit_" + member + "_end"], current, stack);
            };
        })(property);

    };

};
JsonSchemaProvider.prototype._isFunc = function (obj) {
    return (typeof (obj) == "function");
};

JsonSchemaProvider.prototype._popStack = function (key, current, stack) {
    var shouldBeCurrent = stack.pop();
    if (shouldBeCurrent.key != key || shouldBeCurrent.value != current) {
        throw new Error("Stack out of sync");
    }
};

JsonSchemaProvider.prototype._executeAndPopStack = function (key, func, current, stack) {
    this._execute(func, current, stack);
    this._popStack(key, current, stack);
};


JsonSchemaProvider.prototype._execute = function (func, current, stack) {
    if (this._isFunc(func)) {
        func(current, stack);
    };
};

// these are all valid in the root of a schema
// ordinal is significant

JsonSchemaProvider.prototype.attributeNames = ["type",
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

// schema


JsonSchemaProvider.prototype.visit_schema = function (current, stack) {

    stack = stack || [];
    var key = "schema";
    stack.push({ key: key, value: current });

    for (var i = 0; i < this.attributeNames.length; i++) {
        var property = this.attributeNames[i];
        if (typeof (current[property]) != 'undefined') {
            this["visit_" + property](current[property], stack)
        };
    };
    this.visit_schema_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_schema_end = function (current, stack) {
    this._execute(this._writer.visit_schema_end, current, stack);
};


// extends

JsonSchemaProvider.prototype.visit_extends = function (current, stack) {
    var key = "extends";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_extends, current, stack);
    this.visit_extends_end(key, current, stack);
};



// type

JsonSchemaProvider.prototype.visit_type = function (current, stack) {

    var key = "type";
    stack.push({ key: key, value: current });

    if (current.constructor == Array) {
        this.visit_type_union(current, stack);
    } else if (typeof (current) == "string") {
        this.visit_type_simple(current, stack);
    } else {
        throw new Error("schema type not valid");
    };

    this.visit_type_end(key, current, stack);
};


JsonSchemaProvider.prototype.visit_type_simple = function (current, stack) {
    this._execute(this._writer.visit_type_simple, current, stack);
    this.visit_type_simple_end(current, stack);
};

JsonSchemaProvider.prototype.visit_type_simple_end = function (current, stack) {

    this._execute(this._writer.visit_type_simple_end, current, stack);

};


JsonSchemaProvider.prototype.visit_type_union = function (current, stack) {

    this._execute(this._writer.visit_type_union, current, stack);
    this.visit_type_union_end(current, stack);

};
JsonSchemaProvider.prototype.visit_type_union_end = function (current, stack) {
    this._execute(this._writer.visit_type_union_end, current, stack);
};

// properties

JsonSchemaProvider.prototype.visit_properties = function (current, stack) {

    var key = "properties";
    stack.push({ key: key, value: current });


    this._execute(this._writer.visit_properties, current, stack);

    for (propertyName in current) {
        if (current.hasOwnProperty(propertyName)) {
            var property = current[propertyName];
            this.visit_property(property, stack);
        }
    }

    this.visit_properties_end(key, current, stack);
};


JsonSchemaProvider.prototype.visit_property = function (current, stack) {
    var key = "property";
    stack.push({ key: key, value: current });
    this._execute(this._writer.visit_property, current, stack);
    this.visit_property_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_property_end = function (key,current, stack) {
    this._execute(this._writer.visit_property_end, current, stack);
    this._popStack("property", current, stack);
};

// patternProperties

JsonSchemaProvider.prototype.visit_patternProperties = function (current, stack) {
    var key = "patternProperties";
    stack.push({ key: key, value: current });
    this._execute(this._writer.visit_patternProperties, current, stack);

    // implement traversal logic
    this.visit_patternProperties_end(key, current, stack);
};


// additionalProperties

JsonSchemaProvider.prototype.visit_additionalProperties = function (current, stack) {
    var key = "additionalProperties";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_additionalProperties, current, stack);
    this.visit_additionalProperties_end(key, current, stack);
};


// items

JsonSchemaProvider.prototype.visit_items = function (current, stack) {
    var key = "items";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_items, current, stack);
    this.visit_items_end(key, current, stack);
};

// additionalItems
JsonSchemaProvider.prototype.visit_additionalItems = function (current, stack) {

    var key = "additionalItems";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_additionalItems, current, stack);
    this.visit_additionalItems_end(key, current, stack);
};


// required

JsonSchemaProvider.prototype.visit_required = function (current, stack) {
    var key = "required";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_required, current, stack);
    this.visit_required_end(key, current, stack);
};



// dependencies

JsonSchemaProvider.prototype.visit_dependencies = function (current, stack) {
    var key = "dependencies";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_dependencies, current, stack);
    this.visit_dependencies_end(key, current, stack);
};



// minimum

JsonSchemaProvider.prototype.visit_minimum = function (current, stack) {
    var key = "minimum";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_minimum, current, stack);
    this.visit_minimum_end(key, current, stack);
};

// maximum
JsonSchemaProvider.prototype.visit_maximum = function (current, stack) {
    var key = "maximum";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_maximum, current, stack);
    this.visit_maximum_end(key, current, stack);
};



JsonSchemaProvider.prototype.visit_exclusiveMinimum = function (current, stack) {
    var key = "exclusiveMinimum";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_exclusiveMinimum, current, stack);
    this.visit_exclusiveMinimum_end(key, current, stack);
};


JsonSchemaProvider.prototype.visit_exclusiveMaximum = function (current, stack) {
    var key = "exclusiveMaximum";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_exclusiveMaximum, current, stack);
    this.visit_exclusiveMaximum_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_minItems = function (current, stack) {
    var key = "minItems";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_minItems, current, stack);
    this.visit_minItems_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_maxItems = function (current, stack) {
    var key = "maxItems";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_maxItems, current, stack);
    this.visit_maxItems_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_uniqueItems = function (current, stack) {
    var key = "uniqueItems";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_uniqueItems, current, stack);
    this.visit_uniqueItems_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_pattern = function (current, stack) {
    var key = "pattern";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_pattern, current, stack);
    this.visit_pattern_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_minLength = function (current, stack) {
    var key = "minLength";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_minLength, current, stack);
    this.visit_minLength_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_maxLength = function (current, stack) {
    var key = "maxLength";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_maxLength, current, stack);
    this.visit_maxLength_end(key, current, stack);
};

JsonSchemaProvider.prototype.visit_enum = function (current, stack) {
    var key = "enum";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_enum, current, stack);
    this.visit_enum_end(key, current, stack);
};

// default
JsonSchemaProvider.prototype.visit_default = function (current, stack) {
    var key = "default";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_default, current, stack);
    this.visit_default_end(key, current, stack);
};

// title

JsonSchemaProvider.prototype.visit_title = function (current, stack) {
    var key = "title";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_title, current, stack);
    this.visit_title_end(key, current, stack);
};

// description
JsonSchemaProvider.prototype.visit_description = function (current, stack) {
    var key = "description";
    stack.push({ key: key, value: current });
    this._execute(this._writer.visit_description, current, stack);
    this.visit_description_end(key, current, stack);
};

// format
JsonSchemaProvider.prototype.visit_format = function (current, stack) {
    var key = "format";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_format, current, stack);
    this.visit_format_end(key, current, stack);
};


// divisibleBy

JsonSchemaProvider.prototype.visit_divisibleBy = function (current, stack) {
    var key = "divisibleBy";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_divisibleBy, current, stack);
    this.visit_divisibleBy_end(key, current, stack);
};

// disallow

JsonSchemaProvider.prototype.visit_disallow = function (current, stack) {
    var key = "disallow";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_disallow, current, stack);
    this.visit_disallow_end(key, current, stack);
};

// id

JsonSchemaProvider.prototype.visit_id = function (current, stack) {
    var key = "id";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_id, current, stack);
    this.visit_id_end(key, current, stack);
};

// $ref

JsonSchemaProvider.prototype.visit_$ref = function (current, stack) {
    var key = "$ref";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_$ref, current, stack);
    this.visit_$ref_end(key, current, stack);
};
// $schema

JsonSchemaProvider.prototype.visit_$schema = function (current, stack) {
    var key = "$schema";
    stack.push({ key: key, value: current });
    // implement traversal logic
    this._execute(this._writer.visit_$schema, current, stack);
    this.visit_$schema_end(key, current, stack);
};
