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
        
        switch (patron.preferredAlcohol)
        {
            case AlcoholPref.Whiskey:
                Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.WhiskeyValue);
                Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.WhiskeyValue);
                if (drinkToScore.WhiskeyValue > 0)
                    PreferenceMatches += 1;
                break;
            case AlcoholPref.Vodka:
                Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.VodkaValue);
                Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.VodkaValue);
                if (drinkToScore.VodkaValue > 0)
                    PreferenceMatches += 1;
                break;
            case AlcoholPref.Rum:
                Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.RumValue);
                Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.RumValue);
                if (drinkToScore.RumValue > 0)
                    PreferenceMatches += 1;
                break;
        }

        switch (patron.preferredMixer)
        {
            case MixerPref.Soda:
                Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.SodaValue);
                Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.SodaValue);
                if (drinkToScore.SodaValue > 0)
                    PreferenceMatches += 1;
                break;
            case MixerPref.Coke:
                Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.CokeValue);
                Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.CokeValue);
                if (drinkToScore.CokeValue > 0)
                    PreferenceMatches += 1;
                break;
            case MixerPref.Vermouth:
                Bucks += Mathf.RoundToInt(patron.tipRate * drinkToScore.VermouthValue);
                Score += Mathf.RoundToInt(patron.scoreRate * drinkToScore.VermouthValue);
                if (drinkToScore.VermouthValue > 0)
                    PreferenceMatches += 1;
                break;
        }

        if (drinkToScore.TypeOfGarnish == Garnish.Cherry && patron.preferredGarnish == GarnishPref.Cherry)
        {
            Bucks += Bucks;
            Score += Score;
            PreferenceMatches += 1;
        }

        if (drinkToScore.TypeOfGarnish == Garnish.Lime && patron.preferredGarnish == GarnishPref.Lime)
        {
            Bucks += Bucks;
            Score += Score;
            PreferenceMatches += 1;
        }

        if (drinkToScore.TypeOfGarnish == Garnish.Olive && patron.preferredGarnish == GarnishPref.Olive)
        {
            Bucks += Bucks;
            Score += Score;
            PreferenceMatches += 1;
        }

    }

    public DrinkScore(Drink drinkToScore, FancyPatron fancyPatron)
    {

    }
}
