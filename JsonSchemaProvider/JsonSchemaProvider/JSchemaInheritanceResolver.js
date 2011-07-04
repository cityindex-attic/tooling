/// <reference path="JSchemaProvider.js" />


(function () {

    window.JSchemaInheritanceResolver = function (schema) {
        /// <summary>
        /// InheritanceResolver walks the schema and applies base attributes and
        /// properties to a schema that defines "extends".
        /// </summary>
        this.schema = schema;
    };

    window.JSchemaInheritanceResolver.prototype = {
        resolve: function () {
            var self = this;
            each(self.schema.properties, function (target, name) {
                self.resolveSchema(target);
            });

        },
        resolveSchema: function (target) {



            if (target["extends"]) {

                // not supporting multiple inheritance (yet?)
                if (isArray(target["extends"])) {
                    throw new Error("extends array not supported");
                };

                var base = this.getSchema(target["extends"]);

                if (!base) {
                    throw new Error("could not locate schema " + target["extends"]);
                };

                // first check to see if the base needs extension
                if (base["extends"]) {
                    // this recursion will drill down to the beginning of the 
                    // inheritance for this schema before applying 
                    this.resolveSchema(base);
                }

                this.applyBaseSchema(base, target);
            };

        },
        applyBaseSchema: function (base, target) {
            // apply all attributes of base to target that are not already defined on target
            var self = this;
            each(base, function (value, key) {
                if (!isDefined(target[key])) {
                    target[key] = value;
                };
            });

            // apply all properties of base to target that are not already defined on target
            if (base.properties) {
                each(base.properties, function (value, key) {
                    if (!isDefined(target.properties[key])) {
                        target.properties[key] = value;
                    };
                });
            };


        },
        getSchema: function (key) {

            // very simple and specific local locator
            // normalize the reference.

            // recognizes "#.type", "#/type" and "type"

            if (key.indexOf("#.") > -1 || key.indexOf("#/") > -1) {
                key = key.substring(2);
            };

            if (isDefined(this.schema.properties[key])) {
                return this.schema.properties[key];
            };
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