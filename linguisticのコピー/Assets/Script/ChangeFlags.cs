using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeFlags : MonoBehaviour
{
    public TMP_Text targetCharacter;
    public int listLength;

    [System.NonSerialized]public string[] mondaiText = new string[]{
        //En
        "Today I decided to take a different route to work, and I discovered a lovely little cafe.",
        "I spent hours organizing my book collection, realizing I have more than a hundred novels.",
        "As I walked through the park, I couldn't help but notice how beautiful the flowers looked.",
        //Fr
        "Aujourd'hui, j'ai décidé de prendre un chemin différent pour aller au travail et j'ai découvert un joli petit café.",
        "J'ai passé des heures à organiser ma collection de livres, réalisant que j'ai plus d'une centaine de romans.",
        "En traversant le parc, je n'ai pas pu m'empêcher de remarquer à quel point les fleurs étaient belles.",
        //Es
        "Hoy decidí tomar una ruta diferente al trabajo y descubrí un encantador pequeño café.",
        "Pasé horas organizando mi colección de libros, dándome cuenta de que tengo más de cien novelas.",
        "Mientras caminaba por el parque, no pude evitar notar lo hermosas que se veían las flores.",
        //It
        "Oggi ho deciso di prendere un percorso diverso per andare al lavoro e ho trovato un accogliente piccolo caffè.",
        "Ho passato ore a organizzare la mia collezione di libri e mi sono reso conto di avere oltre cento romanzi.",
        "Mentre attraversavo il parco, non ho potuto fare a meno di notare la bellezza dei fiori.",
        //Ru
        "Сегодня я решил пойти на работу другим маршрутом и обнаружил милое маленькое кафе.",
        "Я потратил несколько часов, организуя свою коллекцию книг, осознав, что у меня более ста романов.",
        "Прогуливаясь по парку, я не мог не заметить, как красиво выглядели цветы.",
        //Uk
        "Сьогодні я вирішив піти на роботу іншим шляхом і знайшов затишну маленьку кав'ярню.",
        "Я провів кілька годин, організовуючи свою колекцію книг, і зрозумів, що у мене понад сотня романів.",
        "Коли я проходив через парк, не міг не помітити, наскільки красивими були квіти.",
        //Ja
        "今日はいつもと違う道を通って会社に行ったら、すてきな小さなカフェを見つけました。",
        "本のコレクションを整理していたら、いつのまにか百冊以上の小説があることに気付きました。",
        "公園を歩いていると、花がとてもきれいだと感じずにはいられませんでした。"
    };
    public void changeFlagNumber(int number/*, string Namae*/)
    {
        targetCharacter.text = mondaiText[number];
        /*switch (Namae)
        {
            case "All":
                targetCharacter.text = mondaiText[number];
                break;
            case "USSR":
                targetCharacter.text = mondaiText[number];
                break;
        }*/
    }
}