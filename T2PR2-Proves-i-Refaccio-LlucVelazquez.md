# T2. PR2. Proves i refacció

## 1. 

**Quines són les característiques i els escenaris d'ús de les metodologies àgils de desenvolupament de programari? Explica amb detall i posa un exemple.**

Els principis bàsics de la metodologia àgil són:

* Els individus i les seves interaccions per sobre dels processos i les eines  
* El programari que funciona per sobre de la documentació exhaustiva  
* La col·laboració amb el client per sobre de la negociació de contractes  
* La resposta davant del canvi per sobre de seguir un pla tancat

El Manifest per al desenvolupament de programari àgil es basa en dotze principis:

1. Satisfacció del client mitjançant el lliurament anticipat i continu de programari valuós.  
2. Benvinguts els requisits canviants, fins i tot en el desenvolupament tardà.  
3. Entrega programari que funcioni amb freqüència (setmanes en lloc de mesos).  
4. Col·laboració estreta i diària entre empresaris i desenvolupadors.  
5. Els projectes es construeixen al voltant d'individus motivats, en els quals cal confiar.  
6. La conversa cara a cara és la millor forma de comunicació (coubicació).  
7. El programari en funcionament és la mesura principal del progrés.
8. Desenvolupament sostenible, capaç de mantenir un ritme constant.  
9. Atenció contínua a l'excel·lència tècnica i al bon disseny.  
10. La senzillesa, l'art de maximitzar la quantitat de treball not realitzat, és essencial.  
11. Les millors arquitectures, requisits i dissenys sorgeixen d'equips autoorganitzats.  
12. Periòdicament, l'equip reflexiona sobre com ser més efectiu i s'ajusta en conseqüència.

Scrum, kanban

***

## 2

**Què són els dobles de prova? Explica amb detall els diferents tipus i posa un exemple d’ús per a una solució en C#.**

Els dobles de prova són objectes que simulen el comportament de dependències reals en tests unitaris, permetent provar parts específiques d'una aplicació de forma aïllada

#### Tipus de dobles de prova

##### Dummy:

Els dobles de prova “Dummy” són aquells que són utilitzats simplement per proporcionar una implementació buida per a una dependència necessària al nostre codi. S'utilitzen principalment quan necessitem un objecte per complir una signatura de mètode o una interfície, però no tenim intenció d'utilitzar realment aquest objecte.

Exemple: 
```
public interface ICreditCard
{
    void ProcessPayment(decimal amount);
}

public class DummyCreditCard : ICreditCard`
{
    public void ProcessPayment(decimal amount) 
    {
        // No fa res
    }
}
```

##### Stub:

Els dobles de prova Stub són aquells que es fan servir per simular el comportament d'una dependència en un entorn de proves. Aquests dobles proporcionen respostes predefinides a certes entrades i són molt útils per provar com la nostra aplicació es comporta a diferents escenaris.

Exemple:
```
public interface IDiscountService
{
    decimal GetDiscount(string customerId);
}

public class DiscountServiceStub : IDiscountService
{
    public decimal GetDiscount(string customerId)
    {
        return 0.1m; // Retorna sempre un 10% de descompte
    }
}
```

##### Fake:

Els fakes imiten el comportament d'una dependència real però amb una implementació simplificada. Són útils quan la dependència és complexa o difícil de configurar en un entorn de proves.

Exemple
```
public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public class FakeEmailService : IEmailService
{
    public List<string> SentEmails { get; } = new List<string>();

    public void SendEmail(string to, string subject, string body)
    {
        SentEmails.Add($"To: {to}, Subject: {subject}, Body: {body}");
    }
}
```

##### Spy:

Els dobles de prova “Spy” són aquells que registren el comportament d'una dependència durant una prova per poder verificar-ne el funcionament correcte.
Aquests dobles són molt útils quan volem assegurar-nos que una dependència es fa servir correctament i que està produint el resultat esperat.

##### Mock:

Els mocks s'utilitzen per verificar el comportament d'una dependència durant una prova. Permeten comprovar si certs mètodes han estat cridats amb els paràmetres esperats.

Exemple
```
[Test]
public void TestCustomerPurchase()
{
    var mockCreditCard = new Mock<ICreditCard>();
    var customer = new Customer(mockCreditCard.Object);

    customer.MakePurchase(100);

    mockCreditCard.Verify(cc => cc.ProcessPayment(100), Times.Once);
}
```
***

## 3

**Què és CI/CD? Fes un vídeo explicant les característiques bàsiques, el seu flux de treball i un exemple pràctic d’integració amb GitHub d’una solució en C#.**

### **Què és CI/CD?**

CI/CD (Integració Contínua i Desplegament Continu) és una pràctica de desenvolupament de programari que automatitza els processos de construcció, proves i desplegament de codi

### **Característiques bàsiques**

* Automatització del procés de construcció i proves  
* Integració freqüent del codi en un repositori compartit  
* Detecció primerenca d'errors  
* Desplegament automatitzat a diferents entorns

### **Flux de treball típic**

1. Els desenvolupadors fan push dels canvis al repositori  
2. Es dispara automàticament el procés de CI/CD  
3. Es compila el codi i s'executen les proves automatitzades  
4. Si les proves passen, es desplega automàticament a l'entorn desitjat

### **Exemple pràctic amb GitHub Actions i C\#**

Per integrar CI/CD en un projecte C\# utilitzant GitHub Actions:

##### 1. Crea un arxiu YAML a la carpeta `.github/workflows` del teu repositori  

##### 2. Configura el trigger, per exemple:

text  
`on:`  
  `push:`  
    `branches: [ main ]`

##### 3. Defineix els jobs i steps per compilar i provar el codi C\#:

text  
`jobs:`  
  `build:`  
    `runs-on: ubuntu-latest`  
      
    `steps:`  
    `- uses: actions/checkout@v2`  
    `- name: Setup .NET`  
      `uses: actions/setup-dotnet@v1`  
      `with:`  
        `dotnet-version: 5.0.x`  
    `- name: Restore dependencies`  
      `run: dotnet restore`  
    `- name: Build`  
      `run: dotnet build --no-restore`  
    `- name: Test`  
      `run: dotnet test --no-build --verbosity normal`

##### 4. Afegeix passos addicionals per al desplegament si és necessari

Aquest workflow compilarà, provarà i potencialment desplegarà la teva aplicació C\# cada vegada que es faci push a la branca principal.

##### Video:

[https://youtu.be/ROVcS4JaKv4](https://youtu.be/ROVcS4JaKv4)
***

## 4.

**Aplica els patrons de refacció més habituals en el codi que trobaràs en aquest enllaç Hauràs de:**

* **crear un projecte vinculat al teu repositori de la tasca**  
* **crear una issue per cada tasca que s’hagi de dur a terme per aplicar els diferents patrons**  
* **tancar les tasques mitjançant Visual Studio i les pull requests (PR)**  
* **crear els tests unitaris per a validar el teu codi**  
* **documentar els patrons que has aplicat i els criteris per a executar els casos de prova**

El priemr que he fet al codi, ha sigut la de crear constants, despres he creat funcions, despres he mogut les variables a dalt del main, despres he borrat els comentaris innecesaris, i per ultim he fet retocs al codi per millorar-lo. 




***

## 6.



***

## 7. 

**Bibliografia**

Sense autor. 3/6/2007. Metodologia Agil. Wikipedia. darrere modificacio 25 set 2024 a les 11:40.  
[https://ca.wikipedia.org/wiki/Metodologia\_%C3%A0gil](https://ca.wikipedia.org/wiki/Metodologia_%C3%A0gil) 

Antonio Leiva. 5/1/2023. ¿Qué son los dobles de test?. DevExpert. 5 enero de 2023.
[https://devexpert.io/dobles-test/](https://devexpert.io/dobles-test/)

Alejandro. Fa 4 anys. ¿Qué es un doble de prueba?. EDteam. Hace 4 años.
[https://ed.team/blog/que-es-un-doble-de-prueba](https://ed.team/blog/que-es-un-doble-de-prueba)

Què és CI/CD? explicam un exemple pràctic d’integració amb GitHub d’una solució en C#.  


\> Exemple pràctic amb GitHub Actions i C\#

Per integrar CI/CD en un projecte C\# utilitzant GitHub Actions:

1\. Crea un arxiu YAML a la carpeta \`.github/workflows\` del teu repositori\[3]

2\. Configura el trigger, per exemple:

\`\`\`yaml  
on:  
  push:  
	branches: \[ main ]  
\`\`\`

3\. Defineix els jobs i steps per compilar i provar el codi C\#:

\`\`\`yaml  
jobs:  
  build:  
	runs-on: ubuntu-latest  
      
	steps:  
	\- uses: actions/checkout@v2  
	\- name: Setup .NET  
  	uses: actions/setup-dotnet@v1  
  	with:  
    	dotnet-version: 5.0.x  
	\- name: Restore dependencies  
  	run: dotnet restore  
	\- name: Build  
  	run: dotnet build \--no-restore  
	\- name: Test  
  	run: dotnet test \--no-build \--verbosity normal  
\`\`\`

4\. Afegeix passos addicionals per al desplegament si és necessari\[3]

Aquest workflow compilarà, provarà i potencialment desplegarà la teva aplicació C\# cada vegada que es faci push a la branca principal.

Citations:  
\[1] [https://github.com/TimboxIntegracion/Ejemplo-CSharp-DLL](https://github.com/TimboxIntegracion/Ejemplo-CSharp-DLL)   
\[2] [https://github.com/vcubells/csharp-examples](https://github.com/vcubells/csharp-examples)   
\[3] [https://www.youtube.com/watch?v=sIhm4YOMK6Q](https://www.youtube.com/watch?v=sIhm4YOMK6Q)   
\[4] [https://www.reddit.com/r/csharp/comments/9wd067/are\_there\_any\_github\_c\_projects\_with\_clean/](https://www.reddit.com/r/csharp/comments/9wd067/are_there_any_github_c_projects_with_clean/)   
\[5] [https://github.com/ConsorciAOC/PADRO](https://github.com/ConsorciAOC/PADRO)   
\[6] [https://ca.wikipedia.org/wiki/Microsoft](https://ca.wikipedia.org/wiki/Microsoft)   
\[7] [https://github.com/enrique7mc/csharp-examples](https://github.com/enrique7mc/csharp-examples)   
\[8] [https://github.com/ConsorciAOC/RPC](https://github.com/ConsorciAOC/RPC)

--

Què són els dobles de prova? Explica amb detall els diferents tipus i posa un exemple d’ús per a una solució en C#.

Els dobles de prova són objectes que s'utilitzen per simular el comportament de dependències reals en un entorn de proves de software[1][2]. Aquests permeten realitzar proves aïllades d'una part específica d'una aplicació sense dependre de la implementació real de les seves dependències.

Hi ha diversos tipus de dobles de prova:

## Dummy

Els dummies són implementacions buides que s'utilitzen simplement per complir amb una signatura de mètode o interfície[1]. No tenen cap lògica i s'usen quan es necessita un objecte per fer que el codi compili.

Exemple en C#:

```csharp
public interface ICreditCard
{
    void ProcessPayment(decimal amount);
}

public class DummyCreditCard : ICreditCard
{
    public void ProcessPayment(decimal amount) 
    {
        // No fa res
    }
}
```

## Stub

Els stubs proporcionen respostes predefinides a crides específiques[1][2]. Són útils per simular diferents escenaris i veure com l'aplicació es comporta.

Exemple en C#:

```csharp
public interface IDiscountService
{
    decimal GetDiscount(string customerId);
}

public class DiscountServiceStub : IDiscountService
{
    public decimal GetDiscount(string customerId)
    {
        return 0.1m; // Retorna sempre un 10% de descompte
    }
}
```

## Fake

Els fakes imiten el comportament d'una dependència real però amb una implementació simplificada[1]. Són útils quan la dependència és complexa o difícil de configurar en un entorn de proves.

Exemple en C#:

```csharp
public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public class FakeEmailService : IEmailService
{
    public List<string> SentEmails { get; } = new List<string>();

    public void SendEmail(string to, string subject, string body)
    {
        SentEmails.Add($"To: {to}, Subject: {subject}, Body: {body}");
    }
}
```

## Mock

Els mocks s'utilitzen per verificar el comportament d'una dependència durant una prova[1][2]. Permeten comprovar si certs mètodes han estat cridats amb els paràmetres esperats.

Exemple en C# utilitzant Moq:

```csharp
[Test]
public void TestCustomerPurchase()
{
    var mockCreditCard = new Mock<ICreditCard>();
    var customer = new Customer(mockCreditCard.Object);

    customer.MakePurchase(100);

    mockCreditCard.Verify(cc => cc.ProcessPayment(100), Times.Once);
}
```

Aquests dobles de prova permeten realitzar proves unitàries més eficients i aïllades, facilitant la detecció d'errors i millorant la qualitat del codi.

Citations:
[1] https://devexpert.io/dobles-test/
[2] https://ed.team/blog/que-es-un-doble-de-prueba
[3] https://ca.wikipedia.org/wiki/Immunodifusi%C3%B3_doble
[4] https://xurxodev.com/dobles-de-test/
[5] https://www.enciclopedia.cat/aprendre-a-aprendre/els-diferents-tipus-dexamens
[6] https://www.if-assessors.es/ca/periode-prova/
[7] https://triaeducativa.gencat.cat/ca/proves/proves-acces/fp/fp-gs/estructura-temaris/
[8] https://www.infofeina.com/blog/ca/2023/04/21/que-es-el-periode-de-prova/



***