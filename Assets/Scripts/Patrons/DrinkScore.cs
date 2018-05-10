using UnityEngine;

public class DrinkScore
    {

    public int Bucks { get; set; }
    public int Score { get; set; }
    public int PreferenceMatches { get; set; }

    public DrinkScore()
        {
            Bucks = 0;
            Score = 0;
            PreferenceMatches = 0;
        }

    public DrinkScore(Drink drinkToScore, Patron patron)
    {
        DrinkScore thisScore = new DrinkScore();

        switch (patron.preferredAlcohol)
        {
            case AlcoholPref.Whiskey:
                thisScore.Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.WhiskeyValue);
                thisScore.Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.WhiskeyValue);
                if (drinkToScore.WhiskeyValue > 0)
                    thisScore.PreferenceMatches += 1;
                break;
            case AlcoholPref.Vodka:
                thisScore.Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.VodkaValue);
                thisScore.Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.VodkaValue);
                if (drinkToScore.VodkaValue > 0)
                    thisScore.PreferenceMatches += 1;
                break;
            case AlcoholPref.Rum:
                thisScore.Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.RumValue);
                thisScore.Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.RumValue);
                if (drinkToScore.RumValue > 0)
                    thisScore.PreferenceMatches += 1;
                break;
        }

        switch (patron.preferredMixer)
        {
            case MixerPref.Soda:
                thisScore.Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.SodaValue);
                thisScore.Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.SodaValue);
                if (drinkToScore.SodaValue > 0)
                    thisScore.PreferenceMatches += 1;
                break;
            case MixerPref.Coke:
                thisScore.Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.CokeValue);
                thisScore.Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.CokeValue);
                if (drinkToScore.CokeValue > 0)
                    thisScore.PreferenceMatches += 1;
                break;
            case MixerPref.Vermouth:
                thisScore.Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.VermouthValue);
                thisScore.Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.VermouthValue);
                if (drinkToScore.VermouthValue > 0)
                    thisScore.PreferenceMatches += 1;
                break;
        }

        if (drinkToScore.TypeOfGarnish == Garnish.Cherry && patron.preferredGarnish == GarnishPref.Cherry)
        {
            thisScore.Bucks += thisScore.Bucks;
            thisScore.Score += thisScore.Score;
            thisScore.PreferenceMatches += 1;
        }

        if (drinkToScore.TypeOfGarnish == Garnish.Lime && patron.preferredGarnish == GarnishPref.Lime)
        {
            thisScore.Bucks += thisScore.Bucks;
            thisScore.Score += thisScore.Score;
            thisScore.PreferenceMatches += 1;
        }

        if (drinkToScore.TypeOfGarnish == Garnish.Olive && patron.preferredGarnish == GarnishPref.Olive)
        {
            thisScore.Bucks += thisScore.Bucks;
            thisScore.Score += thisScore.Score;
            thisScore.PreferenceMatches += 1;
        }

    }

    public DrinkScore(Drink drinkToScore, FancyPatron fancyPatron)
    {

    }
}
