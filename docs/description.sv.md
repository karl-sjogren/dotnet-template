# Projektinställningar

## .csproj

Exempel på en .csproj-fil från ett nyskapat console-projekt i .NET 9.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

### Sdk

Den SDK som projektet använder styr en mängd olika saker som hur projektet
kompileras, hur det publiceras, vilka paket som implicit inkluderas och mycket
mer.

Inbyggda i .NET Core SDK

* Microsoft.NET.Sdk
* Microsoft.NET.Sdk.Web
* Microsoft.NET.Sdk.Worker
* Microsoft.NET.Sdk.Razor
* Microsoft.NET.Sdk.Desktop

Exempel på NuGet-paket med nya SDKer

* Microsoft.Build.NoTargets/3.7.56
* Microsoft.VisualStudio.JavaScript.SDK/1.0.2125207

### PropertyGroup vs ItemGroup

PropertyGroup innehåller egenskaper som har ett namn och ett värde. Egenskaper
som satts i en PropertyGroup kan användas i delar av projektet.

```xml
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <ProjectEmoji>🚀</ProjectEmoji>
  </PropertyGroup>

  <Target Name="RocketOutput" AfterTargets="PostBuildEvent">
    <Exec Command="echo $(ProjectEmoji) From SampleProject.Console.csproj" />
  </Target>
```

ItemGroup innehåller en lista av element, vanligtvis för filer eller referenser till projekt eller nuget-paket.

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
  <TargetFramework>net9.0</TargetFramework>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="1.0.0" />
  <PackageReference Include="Microsoft.CodeAnalysis.BannedApiAnalyzers" Version="1.0.0" />
</ItemGroup>
```

### Condition

`Condition` används för att sätta en egenskap beroende på en annan egenskap. Detta kan användas
för att t.ex. göra vissa saker enbart projektet byggs för Release, eller när det körs på byggservern.

```xml
  <PropertyGroup Condition="'$(Configuration)' == 'Release'">
    <Optimize>true</Optimize>
  </PropertyGroup>
```

### Compile/EmbeddedResource/Content/None

Den SDK man valt för sitt projekt påverkar vilka typer av filer som inkluderas
i projektet som standard. Normalt sett så kompileras C#-filer och VB.NET-filer,
men kör man med `Microsoft.NET.Sdk.Web` så kommer även Razor-filer att kompileras.

Utöver det så kommer t.ex. resursfiler att inkluderas som `EmbeddedResource`.

Vill man däremot själv inkludera eller exkludera filer så kan av olika anledningar
så görs detta med `Compile`-, `EmbeddedResource`-, `Content`- eller `None`-elementet.

* `Compile`
  * Filen kompileras och inkluderas i projektet. Detta är standard för C#- och
    VB.NET-filer.
* `EmbeddedResource`
  * Filen kompileras in i projektet som en inbäddad resurs.
* `Content`
  * Filen är inte en del av kompileringen men kopieras till output-mappen.
* `None`
  * Filen inkluderas inte i projektet.

Exempel på att exkludera en C#-fil från att kompileras i ens projekt

```xml
  <ItemGroup>
    <Compile Remove="Sample.cs" />
  </ItemGroup>
```

Eller exkludera en hel mapp från kompilering

```xml
  <ItemGroup>
    <Compile Remove="Reference/**/*.cs" />
  </ItemGroup>
```

Vill man däremot exkludera en appsettings-fil så är dessa tillagda som
`Content` och måste därför exkluderas som sådana.

```xml
  <ItemGroup>
    <Content Remove="appsettings.Local.json" />
  </ItemGroup>
```

`None` består i vanliga fall all alla övriga filer i ens projekt. Vill
man ändå inkludera några av dessa filer så kan det göras genom att sätta
`CopyToOutputDirectory` till `PreserveNewest` eller `Always`.

```xml
  <ItemGroup>
    <None Include="sqlite.db" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>
```

### PackageReference

`PackageReference` används för att inkludera NuGet-paket i projektet. I sin
enklaste form så ser det ut så här.

```xml
  <ItemGroup>
    <PackageReference Include="CoolPackageWithKittens" Version="1.0.0" />
  </ItemGroup>
```

Detta kommer dock med ett antal default-värden i bakgrunden. Motsvarande
referens om man skriver ut default värdena ser ut så här.

```xml
  <ItemGroup>
    <PackageReference Include="CoolPackageWithKittens" Version="1.0.0">
      <IncludeAssets>all</IncludeAssets>
      <ExcludeAssets>none</ExcludeAssets>
      <PrivateAssets>contentfiles;analyzers;build</PrivateAssets>
    </PackageReference>
  </ItemGroup>
```

`IncludeAssets` styr vad som ska importeras från paketet till projektet.
Som standard är detta allt.

`ExcludeItems` låter en exkludera saker från paketet utan att att behöva
ändra `IncludeAssets` från `all`.

`PrivateAssets` styr vad som ska följa till andra projekt som refererar
det nuvarande projektet. Som standard så kommer t.ex. inte analyzers att
flöda vidare till andra projekt.

Exempel på hur `Microsoft.EntityFrameworkCore.Design` vanligtvis refereras.

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.0">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
</PackageReference>
```

`PrivateAssets` sätts till `all` för att inte inkludera något från paketet
i andra projekt. `IncludeAssets` ändras från `all` till en rätt specifik
lista där framförallt `compile` saknas då det inte är något i paketet som
ska vara en del av kompileringen.

Något intressant man kan göra med detta är att ta en referens på ett paket
i ett projekt säga att det bara ska användas internt i projektet. Exempelvis
på AcadeMedia så har vi ett väldigt lågnivå-paket som heter `SMBLibrary` som
är på tok för kompliceraet för att användas direkt i projektet. Så vi har en
wrapper som förenklar det hela för våra behov. Genom att lägga wrappern i ett
eget projekt där vi sen refererar till `SMBLibrary` och sätter `PrivateAssets`
till `all` så kommer inte resten av projekten automatiskt att inkludera
`SMBLibrary`.

```xml
  <ItemGroup>
    <PackageReference Include="SMBLibrary" PrivateAssets="all" />
    <PackageReference Include="SMBLibrary.Win32" PrivateAssets="all" />
  </ItemGroup>
```

## Directory.Build.props

Att kunna sätta alla dessa ger väldigt mycket möjligheter, men om man har
ett större projekt med många del-projekt så kan det bli mycket att hålla
reda på. Det man då kan göra är att använda sig av en `Directory.Build.props`-fil
som ligger i en överliggande mapp. När MSBuild ska kompilera en .csproj-fil
så kommer den att leta i alla mappar upp till roten av filsystemet efter en
`Directory.Build.props`-fil och inkludera den om den hittas.

Den tar den frösta filen som hittas och inkluderar den i projektet. Ibland
så vill man däremot ha olika filer i olika delar av projektet, t.ex. en
som ligger i rooten med globala inställningar, sen olika för projekt i `src`
och `test`.

För att göra detta så behöver man manuellt inkludera den ovanliggande filen.

```xml
  <PropertyGroup>
    <ParentDirectoryBuildPropsPath>$([MSBuild]::GetPathOfFileAbove('Directory.Build.props', '$(MSBuildThisFileDirectory)..\'))</ParentDirectoryBuildPropsPath>
  </PropertyGroup>
```

## Directory.Packages.props

`Directory.Packages.props` används när man använder sig av Central Package
Management i sitt projekt. Detta gör att

Filen innehåller en eller flera `ItemGroup` med `PackageVersion`-element som
anger vilken version av ett paket som ska användas i projektet. Ute i projektfilerna
sen så referas paketen bara med ett namn. Detta gör att man inte behöver oroa sig
för att olika projekt ska referera olika versioner av samma paket.

Directory.Packages.props

```xml
<ItemGroup>
  <PackageVersion Include="Microsoft.Extensions.Logging.Abstractions" Version="9.0.0" />
</ItemGroup>
```

SampleProject.Core.csproj

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" />
</ItemGroup>
```

Det går även att specificera att alla projekt ska referera ett specifikt paket,
t.ex. en analyzer genom att använda `GlobalPackageReference`.

```xml
<ItemGroup>
  <GlobalPackageReference Include="Roslynator.Analyzers" Version="4.12.10" />
</ItemGroup>
```
