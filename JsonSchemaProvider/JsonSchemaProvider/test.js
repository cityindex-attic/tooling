﻿/// <reference path="JsonSchemaProvider.js" />
/// <reference path="IJsonSchemaWriter.js" />

function test() {

    var provider = new JsonSchemaProvider(new IJsonSchemaWriter());

    var schema = {
        "description": "Example Address JSON Schema",
        "type": "object",
        "properties": {
            "address": {
                "title": "Street name and number",
                "type": "string"
            },
            "city": {
                "title": "City name",
                "type": "string"
            },
            "postalCode": {
                "title": "Zip Code: 2 letters dash five digits",
                "type": "string",
                "pattern": "^[A-Z]{2}-[0-9]{5}$"
            },
            "region": {
                "title": "Optional Region name",
                "type": "string",
                "optional": true
            },
            "country": {
                "title": "Country name",
                "type": "string"
            }
        },
        "additionalProperties": false
    }
    provider.visit_schema(schema, []);

}