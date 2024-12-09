using _241209_jz_cs;
using System.Xml;
using System.IO;
using System.Text;

List<Barlang> lista = new List<Barlang>();

FileStream fs = new FileStream("barlangok.txt", FileMode.Open);
StreamReader sr = new StreamReader(fs);

string sor = sr.ReadLine();

while(!sr.EndOfStream)
{
    Barlang b = new Barlang(sr.ReadLine());
    lista.Add(b);
}

sr.Close();
fs.Close();


double osszeg = 0;
for (int i = 0; i < lista.Count; i++)
{
    if (lista[i].Telepules.Contains("Miskolc"))
    {
        osszeg += lista[i].Melyseg;
    }
}
Console.WriteLine($"4. Feladat: Barlangok száma: {lista.Count}");
Console.WriteLine($"5. Feladat: Az átlagos mélység: {osszeg/lista.Count:0.00} m");

Console.Write("6. Feladat: Kérem a védettségi szintet: ");
string neve = Console.ReadLine();

int max = 0;
bool find = false;
int j = 0;

while (find != true)
{
    for (int i = 0; i < lista.Count; i++)
    {
        if (lista[i].Hossz > max && lista[i].Vedettseg == neve)
        {
            max = lista[i].Hossz;
            j = i;
            find = true;
        }
    }
}
if (find == true)
{
    Console.WriteLine($"\tAzon: {lista[j].Azon}\n\tNév: {lista[j].Nev}\n\tHossz: {lista[j].Hossz}\n\tMélység: {lista[j].Melyseg}\n\tTelepülés: {lista[j].Telepules}");
}
else
{
    Console.WriteLine($"6. Feladat: Nincs ilyen védettségi szinttel barlang az adatok között!");
}

var f7 = lista.GroupBy(v => v.Vedettseg);
Console.WriteLine("7. Feladat: Statisztika");
foreach (var grp in f7)
{
    Console.WriteLine($"\t{grp.Key}:----> {grp.Count()} fő");
}