using ingatlanok;

List<Ingatlan> ingatlanok = new List<Ingatlan>();

if (File.Exists("ingatlanok.txt")) 
{
    foreach (string aktsor in File.ReadAllLines("ingatlanok.txt")) 
    {
        if (!string.IsNullOrWhiteSpace(aktsor)) 
        {
            string[] darabol = aktsor.Split(";");
            if (darabol.Length == 4) 
            {
                if (int.TryParse(darabol[3], out int alapterulet)) 
                {
                    Ingatlan aktualis = new Ingatlan(darabol[0], darabol[1], darabol[2], alapterulet);
                    ingatlanok.Add(aktualis);
                }
                else { Console.WriteLine($"[HIBA] A(z) {darabol[0]} azonosítójú ingatlan adatai hibásak, átugorva!"); }
            }
            else if (darabol.Length == 5) 
            {
                if (int.TryParse(darabol[3], out int alapterulet) && int.TryParse(darabol[4], out int ar))
                {
                    Ingatlan aktualis = new Ingatlan(darabol[0], darabol[1], darabol[2], alapterulet, ar);
                    ingatlanok.Add(aktualis);
                }
                else { Console.WriteLine($"[HIBA] A(z) {darabol[0]} azonosítójú ingatlan adatai hibásak, átugorva!"); }
            }
            else { Console.WriteLine($"[HIBA] A(z) {darabol[0]} sor elemeinek száma nem megfelelő, átugorva!"); }
        }
    }
}
else { Console.WriteLine("[HIBA] A fájl nem létezik"); }
Console.WriteLine("\nIngatlannyilvántartás:");
foreach(Ingatlan i in ingatlanok) 
{
    Console.WriteLine(i.ToString());
}
Console.WriteLine($"\nRegisztrált ingatlanok száma a rendszerben: {Ingatlan.OsszesRegisztraltIngatlan} db");
int legnagyobb = 0;
int hely = 0;
int legnagyobbhely = 0;
foreach(Ingatlan i in ingatlanok) 
{
    if (i.AlapteruletM2 > legnagyobb) 
    {
        legnagyobb = i.AlapteruletM2;
        legnagyobbhely = hely;
    }
    hely++;
}
Console.WriteLine($"\nLegnagyobb alapterületű ingatlan: {ingatlanok[legnagyobbhely].Cim} ({legnagyobb} m2)");
Console.WriteLine($"Fizetendő vagyonszerzési illeték (4%): {Adokalkulator.VagyonszerzesiAdo(ingatlanok[legnagyobbhely].ArEzerFt)} Ft");
double osszesnegyzetmeterar = 0;
foreach(Ingatlan i in ingatlanok) 
{
    osszesnegyzetmeterar += i.NegyzetmeterAr();
}
Console.WriteLine($"\nIngatlanok átlagos négyzetméterára: {osszesnegyzetmeterar / ingatlanok.Count()} Ft/m2");
