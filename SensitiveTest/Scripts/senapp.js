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
        queryHash: ''
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
                    senlist.updateSensitives();
                    senapp.step = 1;
                });
            }
        }
});


// Список экстрасенсов.
senlist = new Vue({
    el: '#senlist',
    data: {
        items: []
    },
    methods: {
        //Начальная загрузка данных по экстрасенсам.
        updateSensitives: function () {
            $.get("/api/sensitive", function (data) {
                senlist.items = data.items;
            });
        }
    }
});

// Инициализация списка экстрасенсов.
senlist.updateSensitives();