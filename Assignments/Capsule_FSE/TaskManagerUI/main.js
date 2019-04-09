(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/Models/task.ts":
/*!********************************!*\
  !*** ./src/app/Models/task.ts ***!
  \********************************/
/*! exports provided: Task */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Task", function() { return Task; });
var Task = /** @class */ (function () {
    function Task() {
    }
    return Task;
}());



/***/ }),

/***/ "./src/app/Service/task-service.service.ts":
/*!*************************************************!*\
  !*** ./src/app/Service/task-service.service.ts ***!
  \*************************************************/
/*! exports provided: TaskServiceService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TaskServiceService", function() { return TaskServiceService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/http */ "./node_modules/@angular/http/fesm5/http.js");
/* harmony import */ var rxjs_Rx__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/Rx */ "./node_modules/rxjs-compat/_esm5/Rx.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var TaskServiceService = /** @class */ (function () {
    function TaskServiceService(_http) {
        this._http = _http;
        // addUrl: string = "http://localhost/TaskManagerService/api/Task/AddTask";
        // updateUrl: string = "http://localhost/TaskManagerService/api/Task/UpdateTask";
        // getUrl: string = "http://localhost/TaskManagerService/api/Task/GetTasks";
        // getParentTaskUrl: string = "http://localhost/TaskManagerService/api/Task/GetParentTasks";
        // endTaskUrl: string = "http://localhost/TaskManagerService/api/Task/EndTask";
        this.addUrl = "http://localhost:50070/api/Task/AddTask";
        this.updateUrl = "http://localhost:50070/api/Task/UpdateTask";
        this.getUrl = "http://localhost:50070/api/Task/GetTasks";
        this.getParentTaskUrl = "http://localhost:50070/api/Task/GetParentTasks";
        this.endTaskUrl = "http://localhost:50070/api/Task/EndTask";
    }
    TaskServiceService.prototype.changesharedTaskID = function (newTaskId) {
        this.sharedTaskID = newTaskId;
    };
    TaskServiceService.prototype.getsharedTaskID = function () {
        return this.sharedTaskID;
    };
    TaskServiceService.prototype.GetTask = function () {
        return this._http.get(this.getUrl)
            .map(function (response) { return response.json(); })
            .catch(function (error) { return rxjs__WEBPACK_IMPORTED_MODULE_3__["Observable"].throw(error); });
    };
    TaskServiceService.prototype.GetParentTasks = function (taskId) {
        return this._http.get(this.getParentTaskUrl + '/' + taskId)
            .map(function (response) { return response.json(); })
            .catch(function (error) { return rxjs__WEBPACK_IMPORTED_MODULE_3__["Observable"].throw(error); });
    };
    TaskServiceService.prototype.GetTaskById = function (taskId) {
        return this._http.get(this.getUrl + '/' + taskId)
            .map(function (response) { return response.json(); })
            .catch(function (error) { return rxjs__WEBPACK_IMPORTED_MODULE_3__["Observable"].throw(error); });
    };
    TaskServiceService.prototype.AddTask = function (task) {
        var body = JSON.stringify(task);
        var headers = new _angular_http__WEBPACK_IMPORTED_MODULE_1__["Headers"]({ 'Content-Type': 'application/json' });
        var options = new _angular_http__WEBPACK_IMPORTED_MODULE_1__["RequestOptions"]({ headers: headers });
        return this._http.post(this.addUrl, body, options)
            .catch(function (error) { return rxjs__WEBPACK_IMPORTED_MODULE_3__["Observable"].throw(error); });
    };
    TaskServiceService.prototype.UpdateTask = function (task) {
        var body = JSON.stringify(task);
        var headers = new _angular_http__WEBPACK_IMPORTED_MODULE_1__["Headers"]({ 'Content-Type': 'application/json' });
        var options = new _angular_http__WEBPACK_IMPORTED_MODULE_1__["RequestOptions"]({ headers: headers });
        return this._http.post(this.updateUrl, body, options)
            .catch(function (error) { return rxjs__WEBPACK_IMPORTED_MODULE_3__["Observable"].throw(error); });
    };
    TaskServiceService.prototype.EndTask = function (taskId) {
        var body = JSON.stringify(taskId);
        var headers = new _angular_http__WEBPACK_IMPORTED_MODULE_1__["Headers"]({ 'Content-Type': 'application/json' });
        var options = new _angular_http__WEBPACK_IMPORTED_MODULE_1__["RequestOptions"]({ headers: headers });
        return this._http.post(this.endTaskUrl, body, options)
            .map(function (response) { return response.json(); })
            .catch(function (error) { return rxjs__WEBPACK_IMPORTED_MODULE_3__["Observable"].throw(error); });
    };
    TaskServiceService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_http__WEBPACK_IMPORTED_MODULE_1__["Http"]])
    ], TaskServiceService);
    return TaskServiceService;
}());



/***/ }),

/***/ "./src/app/UI/add/add.component.css":
/*!******************************************!*\
  !*** ./src/app/UI/add/add.component.css ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n.slider {\n    margin-top: 8px;\n    -webkit-appearance: none;\n    width: 100%;\n    height: 15px;\n    border-radius: 5px;\n    background: #ddd;\n    outline: none;\n    opacity: 0.7;\n    transition: opacity .2s;\n}\n\n.slider:hover {\n    opacity: 1;\n}\n\n.slider::-webkit-slider-thumb {\n    -webkit-appearance: none;\n    appearance: none;\n    width: 25px;\n    height: 25px;\n    border-radius: 50%;\n    background:gray;\n    cursor: pointer;\n}\n\n.slider::-moz-range-thumb {\n    width: 25px;\n    height: 25px;\n    border-radius: 50%;\n    background:gray;\n    cursor: pointer;\n}\n\n.BottomMargin {\n    margin-bottom: 2%;\n}"

/***/ }),

/***/ "./src/app/UI/add/add.component.html":
/*!*******************************************!*\
  !*** ./src/app/UI/add/add.component.html ***!
  \*******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<form class=\"container form-horizontal\">\n  <h4 class=\"BottomMargin\">Add Task</h4>\n  <h6 [hidden]=\"!addSuccess\" style=\"color:green;\">Task added successfully.</h6>\n  <div class=\"form-group\">\n    <label for=\"txtTask\" class=\"col-xs-2\">Task:</label>\n    <div class=\"col-xs-4\">\n      <input type=\"text\" id=\"txtTask\" name=\"txtTask\" [(ngModel)]=\"Task\" required class=\"form-control\">\n      <div [hidden]=\"!showTaskReqError\" class=\"alert-danger\"> Task Name is required! </div>\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label for=\"ranPriority\" class=\"col-xs-2\">Priority:</label>\n    <div class=\"col-xs-4\">\n      <input type=\"range\" class=\"slider\" id=\"ranPriority\" name=\"ranPriority\" [(ngModel)]=\"Priority\" required min=\"0\"\n        max=\"30\" step=\"5\" value=\"0\">\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label for=\"txtParentTask\" class=\"col-xs-2\">Parent Task:</label>\n    <div class=\"col-xs-4\">\n      <select id=\"txtParentTask\" name=\"txtParentTask\" [(ngModel)]=\"ParentTask\" class=\"form-control\">\n        <option *ngFor=\"let c of ParentTaskList\" [ngValue]=\"c\">{{c}}</option>\n      </select>\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label for=\"txtSDate\" class=\"col-xs-2\">Start Date:</label>\n    <div class=\"col-xs-4\">\n      <input type=\"date\" id=\"txtSDate\" name=\"txtSDate\" [min]=\"minDate\" [(ngModel)]=\"StartDate\" required class=\"form-control\">\n      <div [hidden]=\"!showStDateReqError\" class=\"alert-danger\"> Start Date is required! </div>\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label for=\"txtEDate\" class=\"col-xs-2\">End Date:</label>\n    <div class=\"col-xs-4\">\n      <input type=\"date\" id=\"txtEDate\" name=\"txtEDate\" [min]=\"minDate\" [(ngModel)]=\"EndDate\" required class=\"form-control\">\n      <div [hidden]=\"!showEndDateReqError\" class=\"alert-danger\"> End Date is required! </div>\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label class=\"col-xs-2\"></label>\n    <div class=\"col-xs-4\">\n      <button class=\"btn btn-default\" (click)='AddTask()'>Add Task</button>\n      <button class=\"btn btn-default\" (click)='ResetTask()' style=\"margin-left: 5px;\">Reset</button>\n    </div>\n  </div>\n</form>"

/***/ }),

/***/ "./src/app/UI/add/add.component.ts":
/*!*****************************************!*\
  !*** ./src/app/UI/add/add.component.ts ***!
  \*****************************************/
/*! exports provided: AddComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AddComponent", function() { return AddComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _Models_task__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../Models/task */ "./src/app/Models/task.ts");
/* harmony import */ var _Service_task_service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../Service/task-service.service */ "./src/app/Service/task-service.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var AddComponent = /** @class */ (function () {
    function AddComponent(_taskService) {
        this._taskService = _taskService;
        this.Priority = 0;
        this.minDate = new Date().toISOString().split('T')[0];
    }
    AddComponent.prototype.ngOnInit = function () {
        this.GetParentTasks();
    };
    AddComponent.prototype.GetParentTasks = function () {
        var _this = this;
        this._taskService.GetParentTasks(this.TaskId)
            .subscribe(function (res) {
            _this.ParentTaskList = res;
        });
    };
    AddComponent.prototype.ResetTask = function () {
        this.Task = undefined;
        this.ParentTask = undefined;
        this.Priority = 0;
        this.StartDate = undefined;
        this.EndDate = undefined;
    };
    AddComponent.prototype.AddTask = function () {
        var _this = this;
        this.obj = new _Models_task__WEBPACK_IMPORTED_MODULE_1__["Task"]();
        var error = false;
        if (this.Task) {
            this.obj.Task = this.Task;
            this.showTaskReqError = false;
        }
        else {
            this.showTaskReqError = true;
            error = true;
        }
        this.obj.ParentTask = this.ParentTask;
        this.obj.Priority = this.Priority;
        if (this.StartDate) {
            this.obj.StartDate = this.StartDate;
            this.showStDateReqError = false;
        }
        else {
            this.showStDateReqError = true;
            error = true;
        }
        if (this.EndDate) {
            this.obj.EndDate = this.EndDate;
            this.showEndDateReqError = false;
        }
        else {
            this.showEndDateReqError = true;
            error = true;
        }
        if (!error) {
            this._taskService.AddTask(this.obj)
                .subscribe(function (data) {
                console.log(data);
                _this.addSuccess = true;
                _this.Task = undefined;
                _this.ParentTask = undefined;
                _this.Priority = 0;
                _this.StartDate = undefined;
                _this.EndDate = undefined;
            }, function (error) {
                console.log(error);
                this.addSuccess = false;
            }, function () {
                console.log('patyu');
            });
        }
    };
    AddComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-add',
            template: __webpack_require__(/*! ./add.component.html */ "./src/app/UI/add/add.component.html"),
            styles: [__webpack_require__(/*! ./add.component.css */ "./src/app/UI/add/add.component.css")]
        }),
        __metadata("design:paramtypes", [_Service_task_service_service__WEBPACK_IMPORTED_MODULE_2__["TaskServiceService"]])
    ], AddComponent);
    return AddComponent;
}());



/***/ }),

/***/ "./src/app/UI/edit/edit.component.css":
/*!********************************************!*\
  !*** ./src/app/UI/edit/edit.component.css ***!
  \********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n.slider {\n    margin-top: 8px;\n    -webkit-appearance: none;\n    width: 100%;\n    height: 15px;\n    border-radius: 5px;\n    background: #ddd;\n    outline: none;\n    opacity: 0.7;\n    transition: opacity .2s;\n}\n\n.slider:hover {\n    opacity: 1;\n}\n\n.slider::-webkit-slider-thumb {\n    -webkit-appearance: none;\n    appearance: none;\n    width: 25px;\n    height: 25px;\n    border-radius: 50%;\n    background:gray;\n    cursor: pointer;\n}\n\n.slider::-moz-range-thumb {\n    width: 25px;\n    height: 25px;\n    border-radius: 50%;\n    background:gray;\n    cursor: pointer;\n}\n\n.BottomMargin {\n    margin-bottom: 2%;\n}"

/***/ }),

/***/ "./src/app/UI/edit/edit.component.html":
/*!*********************************************!*\
  !*** ./src/app/UI/edit/edit.component.html ***!
  \*********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<form class=\"container form-horizontal\">\n  <h4 class=\"BottomMargin\">Update Task</h4>\n  <h6 [hidden]=\"!updateSuccess\" style=\"color:green;\">Task updated successfully.</h6>\n  <div class=\"form-group\">\n    <label for=\"txtTask\" class=\"col-xs-2\">Task:</label>\n    <div class=\"col-xs-4\">\n      <input type=\"text\" id=\"txtTask\" name=\"txtTask\" [(ngModel)]=\"Task\" required class=\"form-control\">\n      <div [hidden]=\"!showTaskReqError\" class=\"alert-danger\"> Task Name is required! </div>\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label for=\"ranPriority\" class=\"col-xs-2\">Priority:</label>\n    <div class=\"col-xs-4\">\n      <input type=\"range\" class=\"slider\" id=\"ranPriority\" name=\"ranPriority\" [(ngModel)]=\"Priority\" required min=\"0\"\n        max=\"30\" step=\"5\">\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label for=\"txtParentTask\" class=\"col-xs-2\">Parent Task:</label>\n    <div class=\"col-xs-4\">\n      <select id=\"txtParentTask\" name=\"txtParentTask\" value=\"\" [(ngModel)]=\"ParentTask\" class=\"form-control\">\n        <option *ngFor=\"let c of ParentTaskList\" [ngValue]=\"c\">{{c}}</option>\n      </select>\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label for=\"txtSDate\" class=\"col-xs-2\">Start Date:</label>\n    <div class=\"col-xs-4\">\n      <input type=\"date\" id=\"txtSDate\" name=\"txtSDate\" [min]=\"minDate\" [ngModel]=\"StartDate | date:'yyyy-MM-dd'\"\n        (ngModelChange)=\"StartDate = $event\" required class=\"form-control\">\n      <div [hidden]=\"!showStDateReqError\" class=\"alert-danger\"> Start Date is required! </div>\n    </div>\n  </div>\n  <div class=\"form-group\">\n    <label for=\"txtEDate\" class=\"col-xs-2\">End Date:</label>\n    <div class=\"col-xs-4\">\n      <input type=\"date\" id=\"txtEDate\" name=\"txtEDate\" [min]=\"minDate\" [ngModel]=\"EndDate | date:'yyyy-MM-dd'\"\n        (ngModelChange)=\"EndDate = $event\" required class=\"form-control\">\n      <div [hidden]=\"!showEndDateReqError\" class=\"alert-danger\"> End Date is required! </div>\n    </div>\n  </div>\n\n  <div class=\"form-group\">\n    <label class=\"col-xs-2\"></label>\n    <div class=\"col-xs-4\">\n      <button class=\"btn btn-default\" (click)='UpdateTask()'>Update</button>\n      <button class=\"btn btn-default\" [routerLink]=\"['/view']\" style=\"margin-left: 5px;\">Cancel</button>\n    </div>\n  </div>\n</form>"

/***/ }),

/***/ "./src/app/UI/edit/edit.component.ts":
/*!*******************************************!*\
  !*** ./src/app/UI/edit/edit.component.ts ***!
  \*******************************************/
/*! exports provided: EditComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EditComponent", function() { return EditComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _Models_task__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../Models/task */ "./src/app/Models/task.ts");
/* harmony import */ var _Service_task_service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../Service/task-service.service */ "./src/app/Service/task-service.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var EditComponent = /** @class */ (function () {
    function EditComponent(_taskService, route) {
        this._taskService = _taskService;
        this.route = route;
        this.minDate = new Date().toISOString().split('T')[0];
    }
    EditComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.queryParams.subscribe(function (params) {
            _this.taskId = +params["id"];
        });
        this.GetTaskById(this.taskId);
        this.GetParentTasks(this.taskId);
    };
    EditComponent.prototype.GetParentTasks = function (taskId) {
        var _this = this;
        this._taskService.GetParentTasks(taskId)
            .subscribe(function (res) {
            _this.ParentTaskList = res;
        });
    };
    EditComponent.prototype.GetTaskById = function (taskId) {
        var _this = this;
        this._taskService.GetTaskById(taskId)
            .subscribe(function (res) {
            _this.obj = res;
            if (_this.obj != undefined) {
                _this.Task = _this.obj.Task;
                _this.Priority = _this.obj.Priority;
                _this.ParentTask = _this.obj.ParentTask;
                _this.StartDate = _this.obj.StartDate;
                _this.EndDate = _this.obj.EndDate;
            }
        });
    };
    EditComponent.prototype.UpdateTask = function () {
        var _this = this;
        this.obj = new _Models_task__WEBPACK_IMPORTED_MODULE_1__["Task"]();
        var error = false;
        if (this.Task) {
            this.obj.Task = this.Task;
            this.showTaskReqError = false;
        }
        else {
            this.showTaskReqError = true;
            error = true;
        }
        this.obj.TaskID = this.taskId;
        this.obj.ParentTask = this.ParentTask;
        this.obj.Priority = this.Priority;
        if (this.StartDate) {
            this.obj.StartDate = this.StartDate;
            this.showStDateReqError = false;
        }
        else {
            this.showStDateReqError = true;
            error = true;
        }
        if (this.EndDate) {
            this.obj.EndDate = this.EndDate;
            this.showEndDateReqError = false;
        }
        else {
            this.showEndDateReqError = true;
            error = true;
        }
        if (!error) {
            this._taskService.UpdateTask(this.obj)
                .subscribe(function (data) {
                console.log(data);
                _this.updateSuccess = true;
            }, function (error) {
                console.log(error);
                this.updateSuccess = false;
            }, function () {
                console.log('patyu');
            });
        }
    };
    EditComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-edit',
            template: __webpack_require__(/*! ./edit.component.html */ "./src/app/UI/edit/edit.component.html"),
            styles: [__webpack_require__(/*! ./edit.component.css */ "./src/app/UI/edit/edit.component.css")]
        }),
        __metadata("design:paramtypes", [_Service_task_service_service__WEBPACK_IMPORTED_MODULE_2__["TaskServiceService"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"]])
    ], EditComponent);
    return EditComponent;
}());



/***/ }),

/***/ "./src/app/UI/view/view.component.css":
/*!********************************************!*\
  !*** ./src/app/UI/view/view.component.css ***!
  \********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".viewHead{\n    margin-top: 2%;\n}\n.BottomMargin {\n    margin-bottom: 2%;\n}"

/***/ }),

/***/ "./src/app/UI/view/view.component.html":
/*!*********************************************!*\
  !*** ./src/app/UI/view/view.component.html ***!
  \*********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<form class=\"form-horizontal\">\n  <div class=\"container\">\n    <h4 class=\"BottomMargin\">Search Task</h4>\n    <div class=\"row viewHead\">\n      <label class=\"col-xs-2\">Task:</label>\n      <div class=\"col-xs-4\">\n        <input type=\"text\" name=\"txtTask\" [(ngModel)]=\"Task\" (input)=\"filterItem()\" class=\"form-control\">\n      </div>\n      <label class=\"col-xs-2\">Parent Task:</label>\n      <div class=\"col-xs-4\">\n        <input type=\"text\" name=\"txtPTask\" [(ngModel)]=\"ParentTask\" (input)=\"filterItem()\" class=\"form-control\">\n      </div>\n    </div>\n\n    <div class=\"row viewHead\">\n      <label class=\"col-xs-2\">Priority From:</label>\n      <div class=\"col-xs-4\">\n        <input type=\"text\" name=\"txtPrFrom\" [(ngModel)]=\"PriorityFrom\" (input)=\"filterItem()\" class=\"form-control\">\n      </div>\n      <label class=\"col-xs-2\">Priority To:</label>\n      <div class=\"col-xs-4\">\n        <input type=\"text\" name=\"txtPrTo\" [(ngModel)]=\"PriorityTo\" (input)=\"filterItem()\" class=\"form-control\">\n      </div>\n    </div>\n\n    <div class=\"row viewHead\">\n      <label class=\"col-xs-2\">Start Date:</label>\n      <div class=\"col-xs-4\">\n        <input type=\"date\" name=\"dtStDate\" [(ngModel)]=\"StartDate\" (input)=\"filterItem()\" class=\"form-control\">\n      </div>\n      <label class=\"col-xs-2\">End Date:</label>\n      <div class=\"col-xs-4\">\n        <input type=\"date\" name=\"dtEndDate\" [(ngModel)]=\"EndDate\" (input)=\"filterItem()\" class=\"form-control\">\n      </div>\n    </div>\n  </div>\n  <div class=\"container\" style=\"margin-top: 20px;\">\n    <table class=\"table table-hover\">\n      <tr *ngFor=\"let item of filteredList\">\n        <td>\n          <label>Task</label>\n          <br> {{item.Task}}\n        </td>\n        <td>\n          <label>Parent</label>\n          <br> {{item.ParentTask}}\n        </td>\n        <td>\n          <label>Priority</label>\n          <br> {{item.Priority}}\n        </td>\n        <td>\n          <label>Start</label>\n          <br> {{item.StartDate|date:\"MM/dd/yyyy\"}}\n        </td>\n        <td>\n          <label>End</label>\n          <br> {{item.EndDate|date:\"MM/dd/yyyy\"}}\n        </td>\n        <td>\n          <input type=\"button\" class=\"btn btn-default\" [disabled]=\"!item.IsActive\" [routerLink]=\"['/edit']\"\n            [queryParams]=\"{ id: item.TaskID }\" value=\"Edit\">\n        </td>\n        <td>\n          <input type=\"button\" class=\"btn btn-default\" [disabled]=\"!item.IsActive\" (click)='EndTask(item.TaskID)' value=\"End Task\">\n        </td>\n      </tr>\n    </table>\n  </div>\n</form>"

/***/ }),

/***/ "./src/app/UI/view/view.component.ts":
/*!*******************************************!*\
  !*** ./src/app/UI/view/view.component.ts ***!
  \*******************************************/
/*! exports provided: ViewComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ViewComponent", function() { return ViewComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _Service_task_service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../Service/task-service.service */ "./src/app/Service/task-service.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ViewComponent = /** @class */ (function () {
    function ViewComponent(_taskService) {
        this._taskService = _taskService;
    }
    ViewComponent.prototype.ngOnInit = function () {
        this.GetTask();
    };
    ViewComponent.prototype.GetTask = function () {
        var _this = this;
        this._taskService.GetTask()
            .subscribe(function (res) {
            _this.list = res;
            _this.assignCopy();
        });
    };
    ViewComponent.prototype.assignCopy = function () {
        this.filteredList = Object.assign([], this.list);
    };
    ViewComponent.prototype.filterItem = function () {
        var _this = this;
        debugger;
        if (!this.Task && !this.ParentTask && !this.PriorityFrom && !this.PriorityTo && !this.StartDate && this.EndDate)
            this.assignCopy();
        this.filteredList = Object.assign([], this.list).filter(function (item) { return (_this.Task != undefined ? item.Task.toLowerCase().indexOf(_this.Task.toLowerCase()) > -1 : true) &&
            (_this.ParentTask != undefined ? item.ParentTask.toLowerCase().indexOf(_this.ParentTask.toLowerCase()) > -1 : true) &&
            (_this.PriorityFrom != undefined ? item.Priority >= _this.PriorityFrom : true) &&
            (_this.PriorityTo != undefined ? item.Priority <= _this.PriorityTo : true) &&
            (_this.StartDate != undefined ? item.StartDate.indexOf(_this.StartDate) > -1 : true) &&
            (_this.EndDate != undefined ? item.EndDate.indexOf(_this.EndDate) > -1 : true); });
    };
    ViewComponent.prototype.EndTask = function (taskID) {
        this._taskService.EndTask(taskID)
            .subscribe(function (data) {
            console.log(data);
            window.location.reload();
        }, function (error) {
            console.log(error);
        }, function () {
            console.log('patyu');
        });
    };
    ViewComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-view',
            template: __webpack_require__(/*! ./view.component.html */ "./src/app/UI/view/view.component.html"),
            styles: [__webpack_require__(/*! ./view.component.css */ "./src/app/UI/view/view.component.css")]
        }),
        __metadata("design:paramtypes", [_Service_task_service_service__WEBPACK_IMPORTED_MODULE_1__["TaskServiceService"]])
    ], ViewComponent);
    return ViewComponent;
}());



/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".BottomMargin {\n    margin-bottom: 1%;\n}"

/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"container BottomMargin\">\n    <h1>Task Manager</h1>\n    <nav>\n        <a [routerLink]=\"'/add'\">Add Task</a> |\n        <a [routerLink]=\"'/view'\">View Task</a>\n    </nav>\n</div>\n<router-outlet></router-outlet>"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'TaskManagerUI';
    }
    AppComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _UI_add_add_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./UI/add/add.component */ "./src/app/UI/add/add.component.ts");
/* harmony import */ var _UI_edit_edit_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./UI/edit/edit.component */ "./src/app/UI/edit/edit.component.ts");
/* harmony import */ var _UI_view_view_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./UI/view/view.component */ "./src/app/UI/view/view.component.ts");
/* harmony import */ var _app_routes__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./app.routes */ "./src/app/app.routes.ts");
/* harmony import */ var _Service_task_service_service__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./Service/task-service.service */ "./src/app/Service/task-service.service.ts");
/* harmony import */ var _angular_http__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/http */ "./node_modules/@angular/http/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};











var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"],
                _UI_add_add_component__WEBPACK_IMPORTED_MODULE_5__["AddComponent"],
                _UI_edit_edit_component__WEBPACK_IMPORTED_MODULE_6__["EditComponent"],
                _UI_view_view_component__WEBPACK_IMPORTED_MODULE_7__["ViewComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
                _angular_http__WEBPACK_IMPORTED_MODULE_10__["HttpModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_3__["RouterModule"].forRoot(_app_routes__WEBPACK_IMPORTED_MODULE_8__["appRoutes"])
            ],
            providers: [_Service_task_service_service__WEBPACK_IMPORTED_MODULE_9__["TaskServiceService"]],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/app.routes.ts":
/*!*******************************!*\
  !*** ./src/app/app.routes.ts ***!
  \*******************************/
/*! exports provided: appRoutes */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "appRoutes", function() { return appRoutes; });
/* harmony import */ var _UI_add_add_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./UI/add/add.component */ "./src/app/UI/add/add.component.ts");
/* harmony import */ var _UI_edit_edit_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./UI/edit/edit.component */ "./src/app/UI/edit/edit.component.ts");
/* harmony import */ var _UI_view_view_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./UI/view/view.component */ "./src/app/UI/view/view.component.ts");



var appRoutes = [
    { path: '', component: _UI_add_add_component__WEBPACK_IMPORTED_MODULE_0__["AddComponent"] },
    { path: 'add', component: _UI_add_add_component__WEBPACK_IMPORTED_MODULE_0__["AddComponent"] },
    { path: 'edit', component: _UI_edit_edit_component__WEBPACK_IMPORTED_MODULE_1__["EditComponent"] },
    { path: 'view', component: _UI_view_view_component__WEBPACK_IMPORTED_MODULE_2__["ViewComponent"] }
];


/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * In development mode, for easier debugging, you can ignore zone related error
 * stack frames such as `zone.run`/`zoneDelegate.invokeTask` by importing the
 * below file. Don't forget to comment it out in production mode
 * because it will have a performance impact when errors are thrown
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\New folder\Senthil\Capsule\Project\Git-Projects-TaskManagerBranch\TaskManager\Source Code\TaskManagerUI\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map