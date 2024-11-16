**Техническое задание на проект: FPS rogulike на Unity**

### Описание
Разработать FPS-игру с элементами рогалика и генерируемым лабиринтом.
Лабиринт генерируется заготовленными блоками. Следующий блок выбирается по подобию выбора следующего тетромино в Tetris. Создаётся набор из возможных элементов. Из этого набора случайно выбирается один, пока каждый не появится один раз, без повторений. После этого набор перезаполняется, процесс повторяется.

Проект должен быть загружен на GitHub с корректно оформленным README, содержащим описание игры и инструкции по запуску.

### Требования:
1. **Игровой процесс:**
   - Игрок может **бегать** по уровням.
   - Камера управляется от первого лица
   - У игрока есть оружие и он может стрелять
   - Блоки генерируются бесконечно до поражения игрока
   - Управление должно быть **отзывчивым** — действия персонажа происходят мгновенно по нажатию кнопок.
   
2. **Блоки:**
   - Игра должна содержать **4** вида блоков лабиринта с нарастающей сложностью(увеличиваются характеристики врагов и/или их количество).
   - Так как генерация бесконечна, то нужно адаптировать блоки к возможности усложнения в **runtime**
   - Блок должен представлять собой небольшой проходимый лабиринт с одним входом и минимум одним выходом(*прямой коридор не считается лабиринтом, коридор с двумя поворотами считается*) 
   - Блок считается пройденным и игрок переходит к следующему если смог победить всех врагов на блоке или смог дойти не проиграв до одного из его выходов(при желании можно оставить только одно условие)
   - Переход между блоками должен быть **бесшовным**. Т.е. для игрока не должно быть заметно, что на сцену добавился новый путь. Со стороны игрока всё выглядит как один длинный уровень. Переход только ногами игрока (телепортация не считается бесшовным переходом). Можно использовать двери, если они не будут телепортировать игрока.
   - Возвращаться в пройденные блоки нельзя
   
3. **Враги:**
   - Должны быть реализованы **два типа врагов**:
     1. **Бегущий враг**, перемещается по поверхности, на ходу стреляет в игрока с малой точностью, но большим уроном.
     2. **Прячущийся враг**, атакует игрока из укрытия. При приближении игрока пытается сменить укрытие. Стрельба более точная, но урон меньше, чем у предыдущего типа врага.

4. **Оружие**
    - Должны быть реализованы **два типа оружия**:
      1. **Основное**. Игрок может из него стрелять по врагам. Тип, точность и дальность стрельбы на усмотрение команды. Дальность не может быть бесконечной. Количество выстрелов неограничено или игрок может его легко пополнить во время игры. Если возможна ситуация, когда игрок остался без боезапаса на основном оружии и без возможности его пополнить, то это засчитывается за softlock и за **ошибку** в разработке. 
      2. **Граната**, метательное оружие, которое перемещается по параболле и при приземлении наносит урон всем противникам в радиусе. Игрок имеет ограниченное количество гранат на блок. При переходе в следующий блок количество гранат восстанавливается.
    - Типы стрельбы:
	  1. **Автоматический**. Пока игрок держит нажатой кнопку стрельбы, выстрелы происходят с заданой переодичностью.
	  2. **Ручной**. За одно нажатие кнопки стрельбы происходит только один выстрел
    
5. **Меню:**
   - Главное меню с двумя пунктами:
     - **Играть** — начать новую игру.
     - **Выход** — выйти из игры.
   

### Технические требования:
1. **GitHub:**
   - Проект должен быть размещён на GitHub.
   - Репозиторий должен содержать файл **README**, в котором будет:
     - Краткое описание игры.
     - Инструкция по установке и запуску.
   
2. **Чистота кода и структура проекта:**
   - Проект должен быть структурирован и легко читаем.
   - Код должен быть понятен, с комментариями к основным блокам.
   
3. **Оптимизация**
   - Блоки и все связанные с ними GameObject, в которые игрок не может попасть должны быть удалены со сцены. Одновременно на сцене может быть два блока: текущий и следующий.
   - Если будут реализованы пули как самостоятельные GameObject, то они должны удаляться после того как улетели за границы блока.

### Срок выполнения:
- Проект должен быть завершён и загружен на GitHub через 1 месяц от даты выдачи задания.

### Параметры оценки:
- Успешное выполнение всех основных требований оценивается на 8
- Для повышения оценки  необходимо добавить в игру собственную систему прокачки в стиле жанра roguelike, которая включает в себя временные улучшения во время игры и постоянные улучшения между играми за внутриигровую валюту. Валюта должна быть получена за действия во время игры(например по количеству побеждённых врагов, пройденных блоков, собрана во время прохождения блока). Все улучшения между играми **сохраняются** при полном закрытии игры. Если необходимо для реализации, то можно поменять структуру меню. Реализация системы добавляет к оценке от 0 до 2 баллов в зависимости от качества реализации.