// SPDX-FileCopyrightText: 2026 Tayra Sakurai
//
// SPDX-License-Identifier: AGPL-3.0-or-later

/**
 * Receive the connection event.
 * @param {string} user The user who fired the event.
 */
function receiveRequest(user) {
    /**
     * Check out the notification permission.
     */

    console.info(typeof(user));

    if (Notification.permission == "granted") {
        /**
         * Show notification.
         * @lends {Notification}
         */
        new Notification(`${user} が小遣いをリクエストしました．`);
        return;
    }
    Notification.requestPermission()
        .then(
            function (permission) {
                if (permission == "granted") {
                    return new Notification(`${user} が小遣いをリクエストしました．`);
                }
            }
        );
}

/**
 * Event handler
 * @fires connection.on When the request was accepted.
 * @param {string} user The name of user whose request was accepted.
 * @param {string} acceptedUser The name of user who accepted the requester's request.
 */
function acceptedRequest(user, acceptedUser) {
    if (!("Notification" in window)) {
        console.error("\"Notification\" is not supported in this browser.");
        return;
    }

    if (Notification.permission == 'granted')
        new Notification(`${acceptedUser} が ${user} のリクエストを承認しました．`);
    else {
        Notification.requestPermission()
            .then(
                function (permission) {
                    if (permission == 'granted')
                        new Notification(`${acceptedUser} が ${user} のリクエストを承認しました．`);
                }
        );
    }
}

/**
 * @type {signalR.HubConnection}
 */
const connection = new signalR.HubConnectionBuilder().withUrl("/RequestHub").build();

connection.on(
    "RequestSent",
    receiveRequest
);

connection.on(
    "RequestAccepted",
    acceptedRequest
);

connection.start();