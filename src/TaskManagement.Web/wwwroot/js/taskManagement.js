function GotoHomePage() {
    location.href = '/Home/Index';
}

function GetEmployeesByProject() {
    var projectId = $('#projects').val();
    $('#employees').empty();

    if (projectId !== '') {
        $.ajax({
            type: "GET",
            url: "/AssignTask/GetEmployeesByProject/" + projectId,
            dataType: "json",
            success: function (data) {
                for (var index = 0; index < data.length; index++) {
                    $('#employees').append($("<option></option>").attr("value", data[index].id).text(data[index].name + " - " + data[index].id));
                }
            },
            error: function () {
                alert("Server Error");
            }
        });
    }
}

function Save() {
    var projectId = $('#projects').val();

    if (projectId === '') {
        alert('Please select a Project.');
        return;
    }

    var description = $('#description').val();

    if (description === '') {
        alert('Description is required.');
        return;
    }

    var startDate = $('#startDate').val();

    if (startDate === '') {
        alert('Start date is required.');
        return;
    }

    var dueDate = $('#dueDate').val();

    if (dueDate === '') {
        alert('Due date is required.');
        return;
    }

    if (new Date(startDate) > new Date(dueDate)) {
        alert('Please select due date equal or greater than the start date.');
        return;
    }

    var employees = $('#employees').val();

    if (employees.length === 0) {
        alert('Please select who should do this task.');
        return;
    }

    postData = {
        EmployeeIds: employees,
        ProjectId: projectId,
        TaskDescription: description,
        TaskDueDate: dueDate,
        TaskStartDate: startDate
    };

    $.ajax({
        type: "POST",
        url: "/AssignTask/SaveTask",
        data: postData,
        dataType: "json",
        success: function (data) {
            if (data === true) {
                alert("Details added successfully");
                GotoHomePage();
            }
            else {
                alert("Save failed");
            }
        },
        error: function () {
            alert("Server Error");
        }
    });
}