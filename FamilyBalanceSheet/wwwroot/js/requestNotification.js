// SPDX-FileCopyrightText: 2026 Tayra Sakurai
//
// SPDX-License-Identifier: AGPL-3.0-or-later

jQuery("form").on(
    "submit",
    function (e) {
        /**
         * @this {EventTarget}
         */

        /**
         * The user name.
         * @type {string}
         */
        const userName = jQuery("#user").first().text();
        connection.invoke("SendRequestNotification", userName).catch(
            function (e) {
                return console.error(e.toString());
            }
        );
    }
);
