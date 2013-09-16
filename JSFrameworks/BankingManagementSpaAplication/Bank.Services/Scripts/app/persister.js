/// <reference path="../libs/_references.js" />
/// <reference path="../libs/sha1.js" />
/// <reference path="../libs/class.js" />

window.persister = (function () {
    var username = "";
    var sessionKey = "";

    function SaveUserData(usernameDb, sessionKeyDb) {
        username = usernameDb;
        sessionKey = sessionKeyDb;

        localStorage.setItem("username", username);
        localStorage.setItem("sessionKey", sessionKey);
    }

    function ClearUserData() {
        username = "";
        sessionKey = "";

        localStorage.removeItem("username");
        localStorage.removeItem("sessionKey");
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersiter(rootUrl);
            this.transactions = new TransactionPersister(rootUrl);
        }
    });

    var UserPersiter = Class.create({
        init: function (rootUrl) {
            this.userUrl = rootUrl + "/users";
        },
        login: function (username, password) {
            var url = this.userUrl + "/login";
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return requester.post(url, user)
             .then(function(data){
                 SaveUserData(data.Username, data.SessionKey);
             },
             function (err) {
                 console.log(err);
             });
        },

        register: function (username, password) {
            var url = this.userUrl + "/register";
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return requester.post(url, user)
            .then(function(data){
                SaveUserData(data.Username, data.SessionKey);
            },
            function (err) {
                console.log(err);
            });
        },

        logout: function () {
            var url = this.userUrl + "/logout";
            
            return requester.put(url, {}, {"X-sessionKey":sessionKey})
            .then(function () {
                ClearUserData();
            });
        }
    });

    var TransactionPersister = Class.create({
        init: function (rootUrl) {
            this.transactionUrl = rootUrl + "/transactions";
        },

        viewLogs: function () {
            return requester.get(this.transactionUrl, { "X-sessionKey": sessionKey });
        },

        deposit: function (sum) {
            var url = this.transactionUrl + "/deposit";
            var updatedAccount = {
                TransactionType: "deposit",
                Date: Date.now(),
                Sum: sum
            };

            return requester.put(url, updatedAccount, {"X-sessionKey" : sessionKey});
        },

        withdraw: function (withdrawSum) {
            var url = this.transactionUrl + "/withdraw";
            var updatedAccount = {
                TransactionType: "withdraw",
                Date: Date.now(),
                Sum: withdrawSum
            };

            return requester.put(url, updatedAccount, {"X-sessionKey" : sessionKey});
        },

        createAcc: function (account) {
            var url = "api/accounts/create";
            var accountCreated = {
                AccountNumber: 1,
                Balance: account
            };

            return requester.post(url, accountCreated, { "X-sessionKey": sessionKey });
        }
    });

    return {
        get: function (rootUrl) {
            return new MainPersister(rootUrl);
        }
    }
}());