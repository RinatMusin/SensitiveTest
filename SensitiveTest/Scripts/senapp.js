// Основное действие - запуск тестирования.
senapp = new Vue({
    el: '#senapp',
    data: {
        // Шаг тестирования: 1- начало тестирования.
        step: 1,
        // Ответы экстрасенсов.
        items: [],
        // Загаданное число пользователем.
        userValue: 0,
        queryHash: '',
        errorMessage: ''
    },
    methods:
        {
            // Запуск тестирования.
            startTest: function () {
                // Переход на следующий шаг.
                senapp.step = 2;

                // Получить ответы экстрасенсов.
                $.get("/api/values", function (data) {
                    console.log(data);
                    senapp.items = data.items;
                    senapp.queryHash = data.queryHash;
                    //senlist.updateSensitives();
                    //senapp.step = 1;
                });
            },

            checkValue: function () {
                $.post("/api/values", { value: senapp.userValue, queryHash: senapp.queryHash }, function (data) {
                    $.cookie("userHash", data.userHash);
                    senapp.errorMessage = data.errorMessage;
                    if (senapp.errorMessage == null) {
                        senapp.userValue = 0;
                        senlist.updateSensitives();
                        answerlist.updateAnswerList();
                        senapp.step = 1;
                    }

                });
            }
        }
});


// Список экстрасенсов.
senlist = new Vue({
    el: '#senlist',
    data: {
        items: [],
        answers: [],
        answerHash:''
    },
    methods: {
        // Начальная загрузка данных по экстрасенсам.
        updateSensitives: function () {
            $.get("/api/sensitive", function (data) {
                senlist.items = data.items;
            });
        },

        // Данные по экстрасенсу  - история угадываний
        sensitiveInfo: function (sHash) {
            if (senlist.answerHash == sHash) {
                senlist.answerHash = '';
            }
            else {
                $.get("/api/sensitive/", { id: sHash }, function (data) {
                    senlist.answers = data.answers;
                    senlist.answerHash = data.hash;
                });
            }
        }
    }
});

// Список ответов пользователя.
answerlist = new Vue({
    el: '#answerlist',
    data: {
        items: []
    },
    methods: {
        // Обновить ответы пользователя.
        updateAnswerList: function () {
            // Получение полного списка ответов пользователя. (Можно сделать конечно и 2 разные функции, полный список и добавление нового значения).
            $.get("/api/answer", function (data) {
                answerlist.items = data.items;
            });
        }
    }
});


// Инициализация списка экстрасенсов.
senlist.updateSensitives();
// Инициализация списка ответов пользователя.
answerlist.updateAnswerList();