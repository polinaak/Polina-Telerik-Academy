/// <reference path="persister.js" />
/// <reference path="../libs/class.js" />


window.ViewModels = (function () {
    var ViewModels = Class.create({
        init: function (persister) {
            this.persister = persister;
            return this;
        },

        loginViewModel: function (successCallback) {
            var self = this;
            var ViewModel = new kendo.observable({

                login: function(){
                    self.persister.user
                    .login(this.get("username"), this.get("password"))
                    .then(function () {
                        successCallback("/home");
                    })
                },
                logout: function () {
                    self.persister.user
                    .logout()
                    .then(function () {
                        successCallback("/login");
                    });

                },
                register: function () {
                    self.persister.user
                    .register(this.get("username"), this.get("password"))
                    .then(function () {
                        successCallback("/home");
                    })
                },

                about: function () {
                    successCallback("/about");
                }
            });
            return ViewModel;
        },


        transactionViewModel: function(successCallback){
            var self = this;
            var ViewModel = new kendo.observable({
                    
                deposit: function(){
                    self.persister.transactions
                    .deposit(this.get("sum"))
                    .then(function () {
                        successCallback("/deposit");
                    });
                },

                withdraw: function () {
                    self.persister.transactions
                    .withdraw(this.get("withdrawSum"))
                    .then(function () {
                        successCallback("/withdraw");
                    });
                },
                
                createAcc: function(){
                    self.persister.transactions
                    .createAcc(this.get("account"))
                    .then(function () {
                        successCallback("account/create");
                    })
                },

                logout: function () {
                    self.persister.user
                    .logout()
                    .then(function () {
                        successCallback("/login");
                    });
                }
            });

            return ViewModel;
        }
    });

    return {
        get: function () {
            return new ViewModels(persister.get("api"))
        }
    }
}());