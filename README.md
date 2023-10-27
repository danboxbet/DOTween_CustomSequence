# DOTween_CustomSequence

 ***Для работы необходимо импортировать в ваш проект [DOTween](https://dotween.demigiant.com/).***
 ![удобно](https://dotween.demigiant.com/_imgs/splash_dotween.png)
 -------------------------------------------------------------------------------------------------------------------------------------------------------
 ***Затем импортируйте*** **<ins>CustomSequence</ins>** ***в папку ассетов.***

 ## Добавление стандартных твинов в секвенцию

 ## Добавление кастомных твинов в секвенцию

 ## Добавление одиночных твинов с привязкой к событиям твинов секвенции
 Каждый стандартный твин имеет события **<ins>OnCompleteBack</ins>** и **<ins>OnCompleteForward</ins>** которые происходят когда выполнена обратная анимация и прямая соответственно.
 > Кастомный твин секвенции (**<ins>CustomTweenSequences</ins>**) не имеет заранее настроенных вызовов событий, но т.к. он наследуется от **<ins>ElementDOTween</ins>**, вы можете настроить вызов этих событий самостоятельно.
 -------------------------------------------------------------------------------------------------------------------------------------------------------
 В вашем скрипте добавьте ссылку на необходимый вам элемент секвенции и подпишитесь на эти события, таким образом у вас появляется возможно запускать твины в течение хода выполнения секвенции.
