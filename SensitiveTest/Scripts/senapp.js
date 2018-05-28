// Основное действие - запуск тестирования.
senapp = new Vue({
    el: '#senapp',
    data: {
        // Шаг тестирования: 1- начало тестирования.
        step: 1
    },
    methods:
        {
            // Запуск тестирования.
            startTest: function () {
                // Переход на следующий шаг.
                this.step = 2;                
            }
        }
});


// Список экстрасенсов.
senlist = new Vue({
    el: '#senlist',
    data: {},
    methods: {
        //Начальная загрузка данных по экстрасенсам.
        init: function ()
        { }
    }
});