
var IJsonSchemaWriter = function () {

};

IJsonSchemaWriter.prototype.visit_schema = function (current, stack) {
    console.log("", current);
};

IJsonSchemaWriter.prototype.visit_extends = function (current, stack) {
    console.log("extends", current);
};


// TYPE

IJsonSchemaWriter.prototype.visit_type_simple = function (current, stack) {
    console.log("type_simple", current);
};

IJsonSchemaWriter.prototype.visit_type_union = function (current, stack) {
    console.log("type_union", current);
};



// PROPERTIES
IJsonSchemaWriter.prototype.visit_properties = function (current, stack) {
    console.log("properties", current);
};

IJsonSchemaWriter.prototype.visit_property = function (current, stack) {
    console.log("property", current);
};




IJsonSchemaWriter.prototype.visit_patternProperties = function (current, stack) {
    console.log("patternProperties", current);
};
IJsonSchemaWriter.prototype.visit_additionalProperties = function (current, stack) {
    console.log("additionalProperties", current);
};
IJsonSchemaWriter.prototype.visit_items = function (current, stack) {
    console.log("items", current);
};
IJsonSchemaWriter.prototype.visit_additionalItems = function (current, stack) {
    console.log("additionalItems", current);
};
IJsonSchemaWriter.prototype.visit_required = function (current, stack) {
    console.log("required", current);
};
IJsonSchemaWriter.prototype.visit_dependencies = function (current, stack) {
    console.log("dependencies", current);
};
IJsonSchemaWriter.prototype.visit_minimum = function (current, stack) {
    console.log("minimum", current);
};
IJsonSchemaWriter.prototype.visit_maximum = function (current, stack) {
    console.log("maximum", current);
};
IJsonSchemaWriter.prototype.visit_exclusiveMinimum = function (current, stack) {
    console.log("exclusiveMinimum", current);
};
IJsonSchemaWriter.prototype.visit_exclusiveMaximum = function (current, stack) {
    console.log("exclusiveMaximum", current);
};
IJsonSchemaWriter.prototype.visit_minItems = function (current, stack) {
    console.log("minItems", current);
};
IJsonSchemaWriter.prototype.visit_maxItems = function (current, stack) {
    console.log("maxItems", current);
};
IJsonSchemaWriter.prototype.visit_uniqueItems = function (current, stack) {
    console.log("uniqueItems", current);
};
IJsonSchemaWriter.prototype.visit_pattern = function (current, stack) {
    console.log("pattern", current);
};
IJsonSchemaWriter.prototype.visit_minLength = function (current, stack) {
    console.log("minLength", current);
};
IJsonSchemaWriter.prototype.visit_maxLength = function (current, stack) {
    console.log("maxLength", current);
};
IJsonSchemaWriter.prototype.visit_enum = function (current, stack) {
    console.log("enum", current);
};
IJsonSchemaWriter.prototype.visit_default = function (current, stack) {
    console.log("default", current);
};
IJsonSchemaWriter.prototype.visit_title = function (current, stack) {
    console.log("title", current);
};
IJsonSchemaWriter.prototype.visit_description = function (current, stack) {
    console.log("description", current);
};
IJsonSchemaWriter.prototype.visit_format = function (current, stack) {
    console.log("format", current);
};
IJsonSchemaWriter.prototype.visit_divisibleBy = function (current, stack) {
    console.log("divisibleBy", current);
};
IJsonSchemaWriter.prototype.visit_disallow = function (current, stack) {
    console.log("disallow", current);
};

IJsonSchemaWriter.prototype.visit_id = function (current, stack) {
    console.log("id", current);
};
IJsonSchemaWriter.prototype.visit_$ref = function (current, stack) {
    console.log("$ref", current);
};
IJsonSchemaWriter.prototype.visit_$schema = function (current, stack) {
    console.log("$schema", current);
};



