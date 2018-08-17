// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open System.Numerics

//[<EntryPoint>]
//let main argv = 
//    printfn "%A" argv
//    0 // return an integer exit code

let inline variables() =
    let i = 1.5
    printfn "i= %f" i
    let j = 10
    printfn "i= %i" j
    let sumfi= i + (j|>float)
    printfn "sumfi %f" sumfi

    // Integral Types
    let degSbyte= 100y
    let degbyte= 100uy
    let degint16= 100s
    let deguint16= 100us
    let degint32= 100
    let deguint32= 100u
    let degint64= 100L
    let deguint64= 100UL
    let degbigint= 14999999999999999999999999999999I
    Console.WriteLine("degSbyte= {0} degbyte= {1} degbyte= {2} deguint16= {3} degint32= {4} 
    deguint32= {5} degint64= {6} deguint64= {7} degbigint= {8}\n",degSbyte,degbyte,degint16,deguint16,degint32,deguint32,degint64,deguint64,degbigint);

    //Floating Point Types
    let flfloat32 = -1653.7F
    let flfloatDo = 6512.9
    let flfloatDec = 1.4999999999999999999999999999999M
    Console.WriteLine("flfloat32= {0} flfloatDo= {1} flfloatDec={2}",flfloat32,flfloatDo,flfloatDec)

    //Text Types
    let tChar= 's'
    let tString= "Sanal Robotik ve Gömülü Sistemler\nTürkçe Karakterler: ÜĞçÇİüğöÖı"
    printfn "tString=%c || tString=%s" tChar tString

    //Other Types
    let bBool= false
    printfn "bBool= %b" bBool

    //mutable vs ref
    Console.WriteLine "\nmutable vs ref\n" // parantez gerek yok.
    let distance speed time = speed*time
    let mutable speed=120 //tercih edilir.
    let time = 6
    speed <- 120-6
    let dist= distance speed time
    printfn "Distance %i" dist

    let changeref= ref 10 //pek yararlı değil.
    changeref := 50
    printfn "changeref= %i" ! changeref
let inline consolePrinting()=
    let sayı= 222
    let big_pi=3.141415926535897932384626433832795028841971M
    let s= "Hello World"
    printfn "Çok fazla basamak var %M" big_pi
    printfn "Sütten%*s" 10 "Peynir"
    printfn @"\n\a\t \\"
let inline functions()=
    let get_sum(x: float, y:float): float= x+y
    printfn "Toplamı= %f" (get_sum(4.4, 3.17))

    let öylemi mi=
        if mi>0 then "öyle"
        elif mi<0 then "öyle değil"
        else "bilmiyorum."
    printfn "öyle mi?=%s" (öylemi 1)

    let rec fact x=
        if x<1 then 1
        else x*fact(x-1)
    printfn "factorial(10)= %i"(fact 10)

    // List ve biraz büyü :)
    let ll=[1..10]
    let randList=List.map(fun x-> x*2) (ll)
    printfn "Listenin iki katı: %A" randList 

    [1..10]
    |> List.filter(fun x -> x%2=0)
    |> List.map(fun x -> x-1)
    |> printfn "Çift sayılar azaltıldı %A"
    (* böyle de yazılabilir.
    let variable= [1..10]
    |> List.filter(fun x -> x%2=0)
    |> List.map(fun x -> x-1)
    printfn "Çift sayılar azaltıldı %A" variable
    *)

    let çarp x= x*4
    let topla y=y+2
    let çarpar_toplar= çarp >> topla
    let toplar_çarpar= çarp << topla // Havalı değil mi? :)
    printfn "çarpar_toplar= %i" (çarpar_toplar 10)
    printfn "toplar_çarpar= %i" (toplar_çarpar 10)
let inline mathLIB()=
    printfn "5+4= %i" (5+4)
    printfn "5-4= %i" (5-4)
    printfn "5*4= %i" (5*4)
    printfn "5/4= %i" (5/4)
    printfn "5%%4= %i" (5%4)
    printfn "5**4= %f" (5.0**4.0) //int türün desteklenmiyor. float olmalı
    
    let sayı= 8
    printfn "Type: %A" sayı.GetType
    printfn "Tipi değişti(float): %.2f" (float sayı)
    printfn "Tipi değişti(int): %i" (int 2.87828)
    
    //Hazır matematik fonksiyonları.
    printfn "abs 4.5 %i" (abs -5)
    printfn "ceil 4.5 %f" (ceil 4.5)
    printfn "floor 4.5 %f" (floor 4.5)
    printfn "log 4.5 %f" (log 10.0) // doğral logaritma yani ln fonksiyonudur.
    printfn "log10 4.5 %f" (log10 100.0)
    printfn "sqrt 4.5 %f" (sqrt 4.0) //(sqrt -4.0) -> Nan sonucunu verir.
let inline stringİşlemleri()=
    let str1= "Limonata ve Karpuz kokteylisi"
    let str2= @"özel ifadeleri ihmal eder. \n \t"
    let str3= """ "Alıntı koyabilirsiniz." Sonra devam edersiniz. """

    let str4= str1 + " " + str3
    printfn "Uzunluk %i" (String.length str4)
    printfn "%c" str1.[1]
    printfn "Büyük harf %s" (str1.ToUpper())
    printfn "ilk kelime: %s" str1.[0..8]

    //let uppersapır= String.collect(fun x -> sprintf "%c, " x ) "commas"
    "commas"
    |> String.collect(fun x -> sprintf "%c, " x ) 
    |> printfn "uppersapır: %s"

    printfn "Büyük harf var mı? %b" (String.exists(fun c -> Char.IsUpper(c)) str4)

    printfn "Number: %b" (String.forall(fun c -> Char.IsDigit(c)) "465")

    let str5= String.init 10 (fun x -> x.ToString())
    printfn "sayaç ileri: %s" str5

    String.iter(fun c -> printfn "%c" c) "printer klavye"
let inline döngü()=
    (*
    Normalde F# dili herşeyde iter fonksiyonu kullanır ama klasik döngü ifadesi de vardır.
    List.iter
    String.iter
    seq.iter
    gibi çok fazla iter ifadesi vardır.
    *)
    let whileDöngü()=
        let tahminEdilen= "2"
        let mutable tahmin= ""

        while not (tahminEdilen.Equals(tahmin)) do
            printfn """Tahmin et: """
            tahmin <- Console.ReadLine()

        printfn "Tebrikler..."
    let forDöngü()=
        printf "yukarı sayıcı: "
        for i=1 to 10 do
            printf "%i," i
        printf "\naşağı sayıcı: "
        for i=10 downto 1 do
            printf "%i," i
        printf "\nrange sayıcı: "
        for i in [1..10] do
            printf "%i," i
        printf "\npipe sayıcı: "
        [1..10] |> List.iter(printf "%i,")

        printf "\nList.reduce: "
        let sum = List.reduce(+) [1..10] // c++ accumulate fonksiyonunun dengi.
        printfn "sum %i" sum
    
    whileDöngü()
    forDöngü()
let inline şartİfadesi()=
    let age= 5
    let ortalama= 3.3
    let mayış= 15000 //Kuvety dövizi Tl*15 ;)

    if age<5 then
        printfn "Annenin yanına dön."
    elif age>=5 && age<20 then
        printfn "Okula git."
    elif age>22 && mayış<1000 then
        printfn "sigorta da vermemişlerdir şimdi..."
    elif age>5 || ortalama >3.0 && mayış >20000 then
        printfn "Hayat sana güzel."
    
    let Ort: string= //switch-case durumunun dengi.
        match age with 
        | age when age<5 -> "okul öncesi"
        | 5-> "anaokulu"
        | age when (age>5 && age<18) -> (age - 5).ToString()
        |_ -> "Üniversite" //varsayılan durum
    printfn "Ortalama: %s" Ort
let inline Listİşleri()=
    let ll=[1..10]
    ll|> List.iter(printfn "Sayı: %i")
    // yada
    printfn "ll: %A" ll

    let list1=5::6::7::8::[]
    printfn "list1: %A" list1

    let list2=[-10..2..10]
    let listChars=['a'..'k']
    printfn "listChars: %A" listChars

    let list3= List.init 5(fun x -> x*2)
    printfn "karesi: %A" list3
    //python gibi liste oluşturma
    let list4= [ for a in 1..5 do yield(a*2) ]
    printfn "list4: %A" list4
    let list4cond= [ for a in 1..20 do if a%3=0 then yield(a*2) ]
    printfn "list4cond: %A" list4cond

    // Yine python benzeri çılgın liste oluşturmak
    let listÇılgın= [ for a in 1 .. 3 do yield![a .. a+2] ]
    printfn "listÇılgın %A" listÇılgın

    // List hazır fonksiyonları
    printfn "uzunluk: %i" listÇılgın.Length
    printfn "boş mu?: %b" listÇılgın.IsEmpty
    printfn "2 elemanda ne var: %c" (listChars.Item(2))
    printfn "Baş eleman: %c" listChars.Head
    printfn "Devamı eleman: %A" listChars.Tail

    let list5= list3|> List.filter(fun x -> x % 2=0) //eşitlik ifadesi "==" yerine sadece "="
    let list6= list5|> List.map(fun x -> x*x)
    printfn "sırala: %A" (List.sort [7; 4; 9; 8; 3])
    printfn "Sum %i" (List.fold(fun sum elem-> sum+elem) 0 [1;2;3]) //List.reduce gibi ama ikinci parametresi var.

type colors= //fonksiyonların dışında oluşturulur.
    | red = 0
    | greed = 1
    | blue = 2
    | opaque = 3
let inline enumlar()=
    let color=colors.red
    match color with
    | red -> "tavşan kanı bunlar..."
    | greed -> "yeşilliktir benim rengim."
    | blue -> "gökyüzü..."
    | opaque -> "saydam."
let inline optionİşlemi()=
    let bölüm x y=
        match y with
        | 0 -> None
        | _ -> Some(x/y)
    
    let valu=(bölüm 4 0)
    if valu.IsSome then printfn "5/0= %A" valu.Value
    elif valu.IsSome then printfn "sıfır ile bölünemez."
    else printfn "birşeyler ters gitti."
let inline tupleİşlemleri()=
    let tup1=(3.0,4.0,5.0)

    let dikdörtgenlerPrizması (x,y,z) : float=
        let hacim= x*y*z
        hacim
    printfn "hacim: %f" (dikdörtgenlerPrizması (2.0,3.0,4.0)) //(dikdörtgenlerPrizması tup1) //olabilir.

    let isim, yaş, data= "Selçuk", 23, 3.14
    let dadata= (isim,yaş,data)

    printfn "isim, yaş, data= %A" dadata

type hesap= //fonksiyonların dışında oluşturulur.
    {isim: string; 
     para: float}
let inline recordİşlemleri()=
    let barış={isim= "Barış Geldi"; para= 1001.5}
    printfn "%s sadece %f parası var." barış.isim barış.para
let inline seqİşlemleri()=
    //python listeleri ve c++ vektörleri gibi istediğin kadar ekle
    //farklı olarak ihtiyaç olduğu sürece üretme işlemini yapar.
    let seq1=seq{1..80}
    let seq2=seq{0..3..20}
    let seq3=seq{50..10}
    printf "%A" seq2
    //veya Listeye çevirebilirsin.
    let print_everthing seq2=
        Seq.toList seq2|> List.iter( printf"%i, " )
    print_everthing seq2

    let is_prime n=
        let rec check i=
            i > n/2 || (n % i <> 0 && check(i+1)) // en az yarısından büyük, aynı zamanda i'nin alabileceği bütün değeri sıfırdan farklı olmalı
        check 2
    
    let primeVals= seq{ for k in 2..1000 do if is_prime k then yield k}
    printfn "\nAsal sayılar listesi= %A" primeVals // hepsini ekrana yazmıyor.
    print_everthing primeVals //önceden tanımlamıştım.
let inline mapİşlemleri()=
    //python ve c# dicionary benzeri ve c++11 map benzeri bir yapı
    //Anahtar <-> Değer tutar.

    let kitaplar= Map.empty.Add("savaş ve barış",400.99).Add("sefiller",450.99).Add("Bence",422.98)
    printfn "Kitap sayısı= %i"kitaplar.Count

    //bulursa hemen fiyatı verir. Bulamazsa None verir.
    let kitapİsmi= kitaplar.TryFind "sefiller"
    match kitapİsmi with
    |Some x -> printfn "fiyatı= %.2f" x
    |None -> printfn "bulunamadı."

    if kitaplar.ContainsKey("bence") then printfn "bence bulundu. Fiyatı: %f" kitaplar.["bence"]
    let kitap2= Map.remove "savaş ve barış" kitaplar
    printfn "# Kitaplar %i" kitap2.Count

let inline add_generics<'T> x y= printfn"%A" (x+y) // fonksiyon içinde izin yok.
let inline genericİşlemler()=
    // python gibi dinamik tipli dillerde ihtiyaç olmaz. c++,c#,rust template yapısı işte.
    //c++ template yapısından çok daha kolay
    add_generics<float> 5.5 1.1
let inline exceptionİşlemleri()=
    let divide x y =
       try
          Some (x / y)
       with
          | :? System.DivideByZeroException as ex-> printfn "Division by zero! %s" ex.Message; None
    printfn "%i"(divide 5 4).Value
    //printfn "%i"(divide 5 0).Value //exception error.

    let divide2 x y BayrakVerdi= //hatayı bilmediğimizi farz edelim ve önemli de değil.
        try
            x/y
        with
        |ex when BayrakVerdi -> printfn "True= %s"(ex.ToString()); 0 // None yerine istediğim değer verdim.
        |ex when not BayrakVerdi -> printfn "False= %s"(ex.ToString()); 1 // None yerine istediğim değer verdim.
    printfn "%i"(divide2 5 4 true)
    //printfn "%i"(divide2 5 0 true) //exception error.

    let divideRaise x y =
       try
       if y=0 then raise(DivideByZeroException "Sıfıra bölünmez.")
       else Some (x / y)
       with
          | :? System.DivideByZeroException as ex-> printfn "Division by zero! %s" ex.Message; None
    printfn "%i"(divide 5 4).Value
    //printfn "%i"(divide 5 0).Value //exception error.

type dikdörtgen= struct // class ve interface kelimeleri de mevcut
    val Lenght: float
    val Height: float
    new (lenght,height)= {Lenght=lenght; Height=height}
end
let inline structİşlemleri()=
    let area(shape: dikdörtgen)=
        shape.Lenght*shape.Height
    
    let rect= new dikdörtgen(4.0,5.0)
    let rect_area=area rect
    printfn "%.2f" rect_area

//fonksiyonel dile nesnel yaklaşım.
type Animal = class
    val Name: string
    val Height: float
    val Weight: float

    new (name,height,weight)={Name=name; Height=height; Weight=weight;}

    member x.Run = printfn "%s Runs" x.Name
end
type Köpek(isim,boy,kilo)= 
    inherit Animal(isim,boy,kilo)
    member x.Bark= printfn "%s Barks" x.Name
let classİşlemleri()=
    let s= new Animal("S",25.85, 40.5)
    s.Run

    let b=new Köpek("B",50.4,10.0)
    b.Run
    b.Bark


let main =
    variables()
    //consolePrinting()
    //functions()
    //mathLIB()
    //stringİşlemleri()
    //döngü()
    //şartİfadesi()
    //Listİşleri()
    //enumlar()
    //optionİşlemi()
    //tupleİşlemleri()
    //recordİşlemleri()
    //seqİşlemleri()
    //mapİşlemleri()
    //genericİşlemler()
    //exceptionİşlemleri()
    //structİşlemleri()
    //classİşlemleri()

    Console.ReadKey()|>ignore

main