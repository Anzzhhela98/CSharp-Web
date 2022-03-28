namespace BookStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data.Models;

    public class CharacteristicSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Characteristics.Any())
            {
                //foreach (var id in dbContext.Characteristics.Select(e => e.Id))
                //{
                //    var entity = new Characteristic { Id = id };
                //    dbContext.Characteristics.Attach(entity);
                //    dbContext.Characteristics.Remove(entity);
                //};
                //;
                //dbContext.SaveChanges();

                //var book = dbContext.Characteristics.Find(20);
                //book.Price = 19.90M;
                //dbContext.SaveChanges();
                return;
            }

            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Понякога лъжа",
                Author = "Алис Фини",
                Description = "Амбър се събужда в болница. Не може да помръдне. Не може да отвори очи. Чува всички разговори около себе си, но никой не подозира за това. Младата жена не помни какво се е случило, за да стигне дотук, но подозира, че съпругът ѝ има вина за станалото. Умело увличайки читателя в задъхано преследване на истината между болничната стая, седмиците преди инцидента и купчина детски дневници отпреди двадесет години, този брилянтен трилър ни води в най-дълбоките и мрачни кътчета на човешкото сърце.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 328,
                Cover = "мека",
                Language = "български",
                Year = 2022,
                DateOfPublication = "22.03.2022 г.",
                UniqueIdBook = "614288",
                ISBN = "9789542838487",
                ImageId = "12600584-a003-4c94-8652-58fd05d865a7",
                IsOnPromotional = true,
                Category = "Mystery",
            });
            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Човекът, който два пъти умря",
                Author = "Ричард Озмън",
                Description = "Дългоочакваната нова книга от поредицата за криминалния клуб „Четвъртък“ вече е тук! Ричард Озмън е забъркал ново предизвикателство от загадки, престъпления и тайни, което е по силите само на проницателните умове на приятелите Елизабет, Джойс, Ибрахим и Рон.",
                Quantity = 100,
                Price = 19.99M,
                Pages = 368,
                Cover = "мека",
                Language = "български",
                Year = 2022,
                DateOfPublication = "25.02.2022 г.",
                UniqueIdBook = "614156",
                ISBN = "9786191517817",
                ImageId = "875bfeb6-06fb-4593-a112-2eedf4a2e528",
                IsOnPromotional = true,
                Category = "World classics",
            });
            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                UniqueIdBook = "83744",
                ISBN = "9786191952458",
                ImageId = "8b35bbea - 8fb3 - 48f7 - 8809 - 924c6b3bca49",
                IsOnPromotional = false,
                Category = "History",
            });
            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Смърт в смокинг",
                Author = "Найо Марш",
                Description = "Новият светски сезон в Лондон е открит и всички са обзети от трескаво вълнение. Сред тях е и изкусен изнудвач, който дебне поредната си жертва. Инспектор Ален е с един ход напред и е внедрил свой приятел. Но точно преди да разобличат престъпника, се появява такси с мъртъв пътник. Шофьорът е убеден, че мъжът е бил убит, но не може да посочи кой е убиецът, нито как е извършено убийството… Ален е на ход да разследва случая, който става все по-необичаен.",
                Quantity = 100,
                Price = 16.99M,
                Pages = 344,
                Cover = "мека",
                Language = "български",
                Year = 2022,
                DateOfPublication = "18.02.2022 г.",
                UniqueIdBook = "614110",
                ISBN = "9786191517817",
                ImageId = "1c7701ef-027a-490a-a931-cfafdbf247bd",
                IsOnPromotional = true,
                Category = "Fantasy",
            });
            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "STEVE JOBS: The Exclusive Biography",
                Author = "Найо Марш",
                Description = "This is a riveting book, with as much to say about the transformation of modern life in the information age as about its supernaturally gifted and driven subject - TelegraphBased on more than forty interviews with Steve Jobs conducted over two years - as well as interviews with more than a hundred family members,friends,adversaries,competitors,and colleagues - this isthe acclaimed,internationally bestselling biography of the ultimate icon of inventiveness.",
                Quantity = 200,
                Price = 15.40M,
                Pages = 608,
                Cover = "мека",
                Language = "английски",
                Year = 2021,
                DateOfPublication = "4.12.2021 г.",
                UniqueIdBook = "29324508",
                ISBN = "9780349145082",
                ImageId = "cc021ad7-0d27-4260-b2db-8932868fe3c9",
                IsOnPromotional = false,
                Category = "Biographies",
            });
            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Хари Потър и философският камък",
                Author = "Дж.Роулинг",
                Description = "Хари Потър не знае нищо за „Хогуортс“ до момента, в който множество мистериозни писма започват да се изсипват в дома на семейство Дърсли на улица „Привит Драйв“. Адресирани до него, надписани със зелено мастило върху жълтеникав пергамент и запечатани с лилав печат, те бързо будят подозрението на противните леля и чичо на момчето и са конфискувани от тях.",
                Quantity = 100,
                Price = 19.90M,
                Pages = 264,
                Cover = "твърда",
                Language = "български",
                Year = 2016,
                DateOfPublication = "18.06.2016 г.",
                UniqueIdBook = "61847",
                ISBN = "9789544464684",
                ImageId = "4d5167c5-7f99-4081-ba6b-148c43dd9fb7",
                IsOnPromotional = false,
                Category = "Fantasy",
            });
            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Хари Потър и Стаята на тайните",
                Author = "	Дж. К. Роулинг",
                Description = "Хари Потър ще запомни лятната ваканция с най-ужасния си рожден ден досега, мрачните предупреждения, идващи от домашно духче на име Доби и… бягството си от дома на семейство Дърсли с помощта на Рон и една магическа летяща кола!",
                Quantity = 100,
                Price = 19.90M,
                Pages = 304,
                Cover = "твърда",
                Language = "български",
                Year = 2016,
                DateOfPublication = "21.11.2016 г.",
                UniqueIdBook = "603927",
                ISBN = "603927",
                ImageId = "8403589d-a52a-491c-84b2-a07b49cae9ce",
                IsOnPromotional = true,
                Category = "Fantasy",
            });
            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Моето семейство и други животни",
                Author = "Джералд Даръл",
                Description = "Като самопровъзгласил се „поборник за правата на дребните грозници” Джералд Даръл (1925–1995) посвещава живота си на съхраняването на природата и животинския свят, без значение дали става въпрос за розовия гълъб от остров Мавриций или за плодовия прилеп на Родригес. Но освен че защитава животните, той и пише забавно и информативно за своя опит и преживелици, докато обикаля света в издирване на животински видове. ",
                Quantity = 100,
                Price = 11.90M,
                Pages = 352,
                Cover = "мека",
                Language = "български",
                Year = 2016,
                DateOfPublication = "17.02.2016 г.",
                UniqueIdBook = "602360",
                ISBN = "9786191506842",
                ImageId = "d85dc17d-575d-43b4-b0b5-70d5377969ce",
                IsOnPromotional = true,
                Category = "Children's",
            });
            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Неграмотното момиче, което можеше да смята",
                Author = "Юнас Юнасон",
                Description = "Поредният шедьовър на Йонасон.В началото на 60 - те години на ХХ век в Йоханесбург идва на бял свят чернокожо момиче.С изключителния си ум и неподозирани способности опровергава очакванията,че ще умре невръстно сред мизерията на Совето.По същото време в Стокхолм се раждат двама еднакви на външност,но коренно различни братя.Съдбата пожелава тримата не само да се срещнат,а и да положат своя отпечатък върху световни събития.",
                Quantity = 100,
                Price = 16.00M,
                Pages = 452,
                Cover = "мека",
                Language = "български",
                Year = 2015,
                DateOfPublication = "13.03.2015 г.",
                UniqueIdBook = "600252",
                ISBN = "9786191504862",
                ImageId = "c230a0b5-c44f-41b6-bfef-954c05f22dc3",
                IsOnPromotional = true,
                Category = "Children's",
            });
        }
    }
}
