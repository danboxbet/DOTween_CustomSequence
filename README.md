# DOTween_CustomSequence

 **Для работы необходимо импортировать в ваш проект [DOTween](https://dotween.demigiant.com/).**
 
 ![удобно](https://dotween.demigiant.com/_imgs/splash_dotween.png)
 -------------------------------------------------------------------------------------------------------------------------------------------------------
 ***Затем импортируйте*** **<ins>CustomSequence</ins>** ***в папку ассетов.***
 
 Для начала работы добавьте компонент **<ins>SettingsElementDOTween</ins>** на нужный объект.
 
  ![Settings](https://github.com/danboxbet/DOTween_CustomSequence/assets/122733719/7bee4ff5-f9a2-47fe-9dab-e0b49cabd286)

 ## Добавление стандартных твинов в секвенцию
 В нашем компоненте отметьте свойства изменения которых хотите добавить в секвенцию и нажмите **Apply Settings**, необходимые компоненты добавятся на объект.
 ### Настройка компонентов
 Далее необходимо настроить компоненты:
 1. *Настройте увеличение масштаба*
 
 ![Scaler](https://github.com/danboxbet/DOTween_CustomSequence/assets/122733719/958661c1-2260-43db-8ff8-59d675f1411d)
 -------------------------------------------------------------------------------------------------------------------------------------------------------
 2. *Настройте увеличить размера шрифта*
 
 ![ScalerText](https://github.com/danboxbet/DOTween_CustomSequence/assets/122733719/4a62c2f8-01f2-4cf2-8354-661b3fff72ce)
 -------------------------------------------------------------------------------------------------------------------------------------------------------
 3. *Настройте заполнение изображения*
 
 ![Filler](https://github.com/danboxbet/DOTween_CustomSequence/assets/122733719/fd38d63a-4a6f-4152-ae40-8efd50bd18a4)
 -------------------------------------------------------------------------------------------------------------------------------------------------------
 ## Добавление кастомных твинов в секвенцию

 ## Добавление одиночных твинов с привязкой к событиям твинов секвенции
 Каждый стандартный твин имеет события **<ins>OnCompleteBack</ins>** и **<ins>OnCompleteForward</ins>** которые происходят когда выполнена обратная анимация и прямая соответственно.
 > Кастомный твин (**<ins>CustomSingleTween</ins>**) не имеет заранее настроенных вызовов событий, но т.к. он наследуется от **<ins>ElementDOTween</ins>**, вы можете настроить вызов этих событий самостоятельно.
>> Путь к примеру твина /CustomSequence/Scripts/CustomsExample/CustomSingleTween.cs
 -------------------------------------------------------------------------------------------------------------------------------------------------------
 В вашем скрипте добавьте ссылку на необходимый вам элемент секвенции и подпишитесь на эти события, таким образом у вас появляется возможность запускать твины в течение хода выполнения секвенции.
