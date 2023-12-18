using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using LinqFaroShuffle;

// query syntax
// var startingDeck = from s in Suits()
//                    from r in Ranks()
//                    select new { Suit = s, Rank = r};

// method syntax
var startingDeck = Suits().SelectMany(s => Ranks().Select(r => new { Suit = s, Rank = r}));
var shuffle = startingDeck;

int times = 0;


shuffle = startingDeck;
do
{
    shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26));
    times++;
} while(!shuffle.CheckSequenceEquality(startingDeck));
      
Console.WriteLine(times);






static IEnumerable<string> Suits()
{
    yield return "hearts";
    yield return "diamonds";
    yield return "clubs";
    yield return "spades";
}

static IEnumerable<string> Ranks() 
{
    yield return "two";
    yield return "three";
    yield return "four";
    yield return "five";
    yield return "six";
    yield return "seven";
    yield return "eight";
    yield return "nine";
    yield return "ten";
    yield return "jack";
    yield return "queen";
    yield return "king";
    yield return "ace";
}