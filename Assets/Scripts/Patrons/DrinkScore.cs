using UnityEngine;

public class DrinkScore
    {

    public int Bucks { get; set; }
    public int Score { get; set; }
    public int PreferenceMatches { get; set; }
    public int GarnishBounus = 100;

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

        if (drinkToScore.TypeOfGarnish == patron.preferredGarnish)
        {
            Bucks += Bucks;
            Score += Score;
            PreferenceMatches += 1;
        }
    }

    public DrinkScore(Drink drinkToScore, FancyPatron fancyPatron)
    {
        int matches = 0;
  
        if (fancyPatron.bigTipper == true)
        {
            
            if (drinkToScore.Whiskey > fancyPatron.WhiskeyValue * 2 && (fancyPatron.TheAlcoholPref == AlcoholPref.Whiskey))
                matches++;
            if (drinkToScore.Vodka > fancyPatron.VodkaValue * 2 && (fancyPatron.TheAlcoholPref == AlcoholPref.Vodka))
                matches++;
            if (drinkToScore.Rum > fancyPatron.RumValue * 2 && (fancyPatron.TheAlcoholPref == AlcoholPref.Rum))
                matches++;
             
        }
        
        
        if ((drinkToScore.Whiskey > fancyPatron.WhiskeyValue) && (fancyPatron.WhiskeyValue > 0))
            matches++;
        if ((drinkToScore.Vodka > fancyPatron.VodkaValue) && (fancyPatron.VodkaValue > 0))
            matches++;
        if ((drinkToScore.Rum > fancyPatron.RumValue) && (fancyPatron.RumValue > 0))
            matches++;
        if ((drinkToScore.Soda > fancyPatron.SodaValue) && (fancyPatron.SodaValue > 0))
            matches++;
        if ((drinkToScore.Coke > fancyPatron.CokeValue && fancyPatron.CokeValue > 0))
            matches++;
        if ((drinkToScore.Vermouth > fancyPatron.VermouthValue && fancyPatron.VermouthValue > 0))
            matches++;

     
        Bucks = matches * fancyPatron.TipRate;
        Score = matches * fancyPatron.ScoreRate;

        if (drinkToScore.TypeOfGarnish == fancyPatron.TypeOfGarnish)
        {
            Bucks += GarnishBounus; //Currently 100, but could be changed
            Score += GarnishBounus;
        }

        if (drinkToScore.TypeOfGarnish == fancyPatron.TypeOfGarnish)  // This is dumb and I hate it but it works and I'm on a time crunch
            matches++;
        PreferenceMatches = matches;
    }
}
