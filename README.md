# ElementalistGame-May19-2020
Card game invented by me, created in C# with windows form and web requests. This is the Client. Own idea.

Reglas/Rules:

4 elementos que son Agua, Fuego, Tierra y Aire.

Cada quien será uno, las cartas son similares a las del juego UNO.

Existen un 0, y pares de cartas del 1-9.

Existen las especiales de cada elemento: 
- El siguiente jugador pierde el turno.
- Intercambia tu mano con el siguiente jugador.
- El siguiente jugador roba 2 cartas del elemento que tiraste.

De esas especiales existen 2 de cada una.

Luego existen las neutrales que son (Las cartas neutrales al no ser de ningun elemento le puede seguir cualquier carta):

- Una carta de valor 9 que será del elemento que seas.
- Una carta que te da +4 puntos en la partida.

El juego empieza y cada quien juega la carta que quiera, pero hay una condición:

- Un elemento de menor valor que el puesto en partida no puede jugarse.

Es decir, si hay un Fuego de valor 5. Las cartas de otro elemento que no sea fuego que valgan entre 0-4 no podrán jugarse.

Las cartas que se juegan van subiendo la puntuacion de cada elemento en partida.

Es decir, si eres Viento y las cartas que se estan colocando en la partida son de tu elemento, a ti unicamente se te subira
la puntuación de los valores de las cartas.

La carta 1: 1 punto.
La carta 2: 2 puntos.
La carta 3: 3 puntos.
...
...
...
La carta 0: 10 puntos.
La carta pierde turno: 4 puntos.
La carta roba 2: 4 puntos.
La carta intercambio de mano: 12 puntos.
La carta de valor 9: 9 puntos.
La carta de +4: 4 puntos (obvio).

En total con la suma de las cartas de tu elemento más las neutrales da: 192 puntos.
La suma de las cartas de tu elemento sin especiales da: 100 puntos.

El primer jugador en llegar a 96 puntos ganará.
