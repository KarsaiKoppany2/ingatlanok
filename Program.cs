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
