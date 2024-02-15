Zde najdete zdrojový kód mé maturitní práce z března roku 2023. 

Hra je postavena na principu herního žánru Roguelike.
V mé verzi hry bojuje hráč proti nepřátelům, které ho za pomocí algoritmu A* pronásledují po náhodně generované mapě tvořené z dílků. 
Pokud se mu podaří zneškodnit všechny vygenerované nepřátelé v úrovni, může pokračovat na těžší úroveň. Ve hře funguje jednoduchý systém odměn – za každou příšerku získává hráč body, za které si po smrti může vylepšit vlastnosti jeho postavy. Tyto vylepšení mu zjednoduší průběh hry a měl by se ideálně dostat dál než při předchozím pokusu.


K vývoji jsem zvolil programovací jazyk C# a framework .NET (Windows Forms). Vývojovým prostředím se vzhledem k možnostem diagnostiky stalo Visual Studio 2022. 
Grafické prostředí včetně animací jsem tvořil pomocí aplikace Photoshop.

Ve hře je využito search algoritmu A*, který se hojně využívá v herním průmyslu. 
Do hry jsem implementoval vlastní diagnostické prostředí, které lépe vizualizuje použité algoritmy a rozhodnutí mého AI nepřátel.

----------------------------------------------------------------------------------
EDIT - 15.2.2024:

Dnes je patrné, že je program špatně optimalizovaný a nesplňuje pravidla a náležitosti objektově orientovaného programování tak, jak by měl. Je potřeba projekt refaktorovat a upravit jej pro maximální efektivnost, srozumitelnost a hlavně čitelnost.
Přesto ho zde ponechám, jelikož si myslím, že kód může sloužit jako dobré porovnání schopností s přítomností a ohlédnutí za tím, co jednou bylo.

Pro případný zájem zde přikládám i dokumentaci k maturitní práci: https://docs.google.com/document/d/e/2PACX-1vRsbNzRydznj3CWjDyEjr6HmONGrU3f01oo38-DaLdtcwJd8LAI1XEcwYa5Rm3gFQ/pub
