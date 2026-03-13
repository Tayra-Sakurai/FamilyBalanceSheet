// SPDX-FileCopyrightText: 2026 Tayra Sakurai
//
// SPDX-License-Identifier: AGPL-3.0-or-later

jQuery('form').on(
    'submit',
    function (e) {
        /**
         * Requested user.
         * @type {string}
         */
        const uid = jQuery(this).find('input.user').first().val();
        /**
         * Accepting user.
         * @type {string}
         */
        const acceptance = jQuery(this).find('input.acceptor').first().val();
        connection.invoke(
            'RequestAcception',
            uid,
            acceptance
        );
    }
);