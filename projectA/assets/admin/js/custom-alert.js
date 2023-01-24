/*SweetAlert Init*/

$(function () {
    "use strict";

    var SweetAlert = function () { };
    SweetAlert.prototype.init = function () {
        
        //Student Manage
        $(".datatable").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/students/delete/" + button.attr("data-student-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });



        $(".user").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/users/delete/" + button.attr("data-user-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });



        //Teacher Manage
        $(".datatable2").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/teachers/delete/" + button.attr("data-teacher-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });


        //Section Manage
        $(".datatable3").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/sections/delete/" + button.attr("data-section-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });



        //Gurdian Manage
        $(".datatable-gurdian").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/guardians/delete/" + button.attr("data-guardian-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });


        //Class Manage
        $(".datatable-class").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/classes/delete/" + button.attr("data-class-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //Class Manage
        $(".datatable-card").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/CardProcessQueues/delete/" + button.attr("data-card-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });


        //Class Manage
        $(".datatable-user").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/Users/delete/" + button.attr("data-user-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //Class TE
        $(".datatable-EvaTeacher").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/TeachersEvaluation/delete/" + button.attr("data-ta-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //Subject Manage
        $(".datatable-subject").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/subjects/delete/" + button.attr("data-subject-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //subject package Manage
        $(".datatable-subPackage").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/SubjectPackages/delete/" + button.attr("data-subPackage-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //subject package details Manage
        $(".datatable-subPackageDetails").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/SubjectPackageDetails/delete/" + button.attr("data-subPackageDetails-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //Sms
        $(".datatable-sms").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/sms/SmsSendings/delete/" + button.attr("data-sms-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //Sms Template
        $(".datatable-smsT").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/sms/SmsSendingTemplates/delete/" + button.attr("data-smsT-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //bookcatagory
        $(".datatable-bookcatagory").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/library/LibraryBookCatagories/delete/" + button.attr("data-bookcatagory-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //bookInfo
        $(".datatable-book").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/library/LibraryBookInfo/delete/" + button.attr("data-book-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });
        //book transection
        $(".datatable-tran").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/library/LibraryTransections/delete/" + button.attr("data-tran-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });


        //staff

        $(".datatable5").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/staffs/delete/" + button.attr("data-staff-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });



        //BillSystem

        $(".datatable-bilsys").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false,
            }, function () {
                $.ajax({
                    url: "/educarepay/BillingSystem/DeleteCustomBill/" + button.attr("data-bill-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
                //window.location = "BillingSystem";
            });
            
        });

        //CmsNotices
        $(".datatable_CMS").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/cms/CmsNotices/delete" + button.attr("data-cms-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });


        //Evaluation Question Manage
        $(".datatable_EvaQuestion").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/teacher/Question/delete/" + button.attr("data-question-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        $(".datatable-examDetails").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/exam/DeleteDetails/" + button.attr("data-examDetails-id"),
                    method: "DELETE",
                    success: function () {
                        table2.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });


        $(".datatable-exam").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/exam/delete/" + button.attr("data-exam-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });



        //Indivisual subject table
        $(".datatable-individualsub").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/Subjects/IndividualSubDelete/" + button.attr("data-subject-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });


        //ExamMarkAssign
        $(".datatable-mark").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/MarkAssign/delete/" + button.attr("data-markAssign-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });



        //ClassTest
        $(".datatable-classtest").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/ClassTest/delete/" + button.attr("data-classtest-id"),
                    method: "GET",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //Evaluation Teacher Manage
        $(".datatable_EvaTeacher").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/teacher/TeacherEvaluation/delete/" + button.attr("data-EvaTeacher-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });

        //Exam Routine
        $(".examroutine").on("click", ".alert_warning", function () {
            var button = $(this);
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    url: "/examroutines/Delete/" + button.attr("data-eroutine-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });
        });
    },
        //init
        $.SweetAlert = new SweetAlert, $.SweetAlert.Constructor = SweetAlert;

    $.SweetAlert.init();
});

