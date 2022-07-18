using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.App.EF.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistryCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationCode = table.Column<long>(type: "bigint", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentTypeName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    NumberOfParticipants = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IndividualUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participations_BusinessUsers_BusinessUserId",
                        column: x => x.BusinessUserId,
                        principalTable: "BusinessUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_IndividualUsers_IndividualUserId",
                        column: x => x.IndividualUserId,
                        principalTable: "IndividualUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participations_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[,]
                {
                    { new Guid("0943c83e-311f-4721-8ae0-fd497d1c57cb"), "Testiminse AS", 77443382 },
                    { new Guid("18ef20cd-475f-4a3c-ba4b-a4996acd5511"), "Tublitöö As", 77443382 },
                    { new Guid("4ab7ac21-e8cc-4958-863f-e139286d8d66"), "Kõva Kate OÜ", 77443382 },
                    { new Guid("a98e23de-92b1-4cb6-a45c-bf61ea83acc3"), "Teeme Tööd OÜ", 77443382 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("344bd9fd-4ab2-473b-b437-73b699619948"), new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saame kokku ja kuulame", "Metsas", "Suvepäevad" },
                    { new Guid("56628a44-e60f-47f8-873d-834a495b227d"), new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osad räägivad, teised kuulavad.", "Ärimajas", "Suvine seminar" },
                    { new Guid("a65af90b-cd4a-4ad9-8961-8531870b0621"), new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasub kindlasti tulla kõigil.", "Aia 33, Tallinn", "Juhi sünnipäev" },
                    { new Guid("ac65b531-1458-4aea-bba8-ddc6c5c5c5bc"), new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osad räägivad, teised kuulavad.", "Linnahall", "Eilene üritus" }
                });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[,]
                {
                    { new Guid("01053f29-420d-d102-ce52-9e140562bdb2"), "Andy", 25038415622L, "A qui quod aut at odio quam molestiae alias. Vel et pariatur. Et voluptatibus laudantium non sit corrupti eveniet cum. Accusamus modi quia. A quaerat recusandae quas qui quia ut perferendis laudantium.", "Koch" },
                    { new Guid("02ab63f5-d5ef-6b2a-15d1-d66c463891c5"), "Kelley", 21107548359L, "Aut sit iste deserunt itaque sit quia eum odit et. Voluptas et doloremque officiis quo quibusdam aut magnam eum voluptatem. Odit voluptas omnis. Quam neque hic blanditiis assumenda non cumque. Delectus magnam tempora incidunt id voluptates pariatur quae cumque.", "Cruickshank" },
                    { new Guid("03ff30b3-3c08-c6c4-2ab6-cd8f009ad206"), "Chasity", 3095527077L, "Inventore et ipsam voluptates repellat explicabo soluta consectetur ullam consectetur. Quo et sed quaerat. Suscipit nesciunt dicta repellat aspernatur aut cum illo. Veniam sequi vitae voluptas nobis.", "Kozey" },
                    { new Guid("0632b746-54ec-b729-b50b-f6af8e208e93"), "Vinnie", 20067248288L, "Alias sed aspernatur eligendi est et dolorum enim quas repellat. Eligendi omnis aut magni possimus at adipisci sit veritatis veniam. Quos repudiandae excepturi natus. Ratione cumque asperiores.", "Borer" },
                    { new Guid("0825842d-8272-6c7d-425b-fa4473658ebe"), "Gustave", 15016443945L, "Quis eum est blanditiis est sunt molestias sunt omnis. Non expedita molestiae. Provident rerum ut rerum. Alias temporibus aut.", "Medhurst" },
                    { new Guid("0c5d2d47-d467-ba6a-2edd-fa616381ea82"), "Bradly", 18047923162L, "Impedit modi fugiat et voluptatum maiores ut. Culpa maxime repellendus et iste ipsum inventore. Inventore distinctio nesciunt perspiciatis iure laudantium eligendi. Ratione cumque ipsa at dolorem voluptatibus vel temporibus earum. Iste harum sunt et et.", "Hilll" },
                    { new Guid("0fa19af5-bbee-1656-1e58-d21b7c445f76"), "Lionel", 11035508998L, "Quia dolor molestiae. Qui et est sit maxime cupiditate. Et ipsa exercitationem occaecati est sit ut qui at porro. Temporibus asperiores est voluptas molestias provident eius non molestiae distinctio. Quae atque at. Et quod fugit.", "Hammes" },
                    { new Guid("15f25553-81bd-7d6a-aac3-1a23636a8eef"), "Dulce", 20056634925L, "Officia dolor quis aut officia et ad expedita sapiente deserunt. Aut at placeat beatae delectus. Id architecto accusamus ipsa voluptas voluptatem quod quo. Et recusandae corrupti quibusdam. Beatae voluptatem fugiat et dolor id ad est.", "Langworth" },
                    { new Guid("167ef49a-e564-edb0-8718-de2118eb7a62"), "Raegan", 22125727291L, "Quia distinctio et odit. Itaque illum dolorem vel ea. Praesentium sit officiis atque sit.", "Cassin" },
                    { new Guid("1bd23c23-ecc1-9482-1efd-cf13e6caafa5"), "Moshe", 7090156718L, "Repudiandae ducimus natus aut et reiciendis voluptas. Qui ipsam praesentium totam. Eum velit ab voluptatem harum accusantium voluptatibus laboriosam. Ipsam et sunt voluptatibus voluptate laborum eos et accusantium est. Provident numquam assumenda atque sit. Omnis harum exercitationem non.", "Braun" },
                    { new Guid("1ed1b6b8-b241-11d7-3910-b1309cfcb176"), "Hyman", 16119530737L, "In quibusdam minima. Nam voluptatum beatae et molestias et alias. Pariatur quae velit recusandae maiores voluptas tempora debitis. Sit eos cupiditate illum nemo molestias est est dignissimos. Vel in adipisci unde qui ad qui maiores.", "Wilkinson" },
                    { new Guid("20bb6fdc-7c72-81e1-1f6d-3d6373ba2b11"), "Chandler", 2067234653L, "Saepe et qui. Facilis sapiente sit dolores. Eos illum minus et nihil quae cumque quibusdam in consequatur. Impedit deserunt veniam voluptate sed molestiae error ea quidem odio.", "Wiza" },
                    { new Guid("2560aee2-aa5c-7671-308b-8d0f830e5687"), "Lenny", 26125528251L, "Excepturi eum qui soluta beatae dolorem dicta odio aut. Porro voluptates est nisi nostrum eum incidunt odio. Accusantium ipsa necessitatibus ea tempora adipisci ab. Repellat itaque est ut eligendi. Ea quaerat quia veritatis sed quia dolore corrupti voluptatem eveniet.", "Kozey" },
                    { new Guid("2664fece-23e1-bf1c-b8b1-2a6c3210f10f"), "Lelah", 5058745520L, "Placeat ut non aliquam facere unde deleniti. Tenetur ut voluptatem fugit culpa non numquam cumque expedita. Recusandae cumque illum occaecati quo eligendi quam vero mollitia.", "Windler" },
                    { new Guid("2a6acf5d-1b3d-6410-e2a9-2fd6835b522f"), "Nichole", 14049503092L, "Modi voluptas quidem magnam. Odio qui et amet dolore tempore debitis cumque. Voluptatum architecto libero praesentium eos facilis recusandae. Quis officiis non ex cupiditate reiciendis. Velit laudantium consequuntur magnam ullam aspernatur totam accusantium. Vero aliquid debitis nihil aut iste qui quisquam aut.", "Tillman" },
                    { new Guid("2b60537d-a27c-1156-23d6-605c2a3f88a4"), "Mekhi", 19040166699L, "Nobis ipsam facilis et fugit veniam est et. Tempora qui voluptates sit ut odit rem ratione unde. Consequatur accusantium consequuntur ipsum quia deleniti consequuntur.", "Gutmann" },
                    { new Guid("328eb90b-6b69-281e-8a07-383f54347713"), "Johan", 21116431510L, "Dignissimos quasi rerum facere. Ipsa accusantium eum illum et nam dolor aut nulla. Molestiae similique porro earum fuga aliquam itaque at architecto. Id id voluptates.", "Stoltenberg" },
                    { new Guid("33723842-1b9b-a9aa-f02a-05b4a7295f85"), "Sarah", 6118038353L, "Qui fugit cum deserunt totam laudantium omnis accusamus voluptas illo. Officiis facere quae qui deleniti ut voluptate ipsum odit. Enim eum voluptatem aut aut qui. Repudiandae corrupti tempora dolorem aperiam et amet. Exercitationem at quae mollitia possimus repellat doloribus qui. Qui aut in reprehenderit et sapiente at illum voluptas voluptatem.", "Bergstrom" },
                    { new Guid("375c096d-5c3f-16d9-9cf5-1d7946530cb6"), "Aisha", 24129911219L, "Et facere neque. Quas accusantium sunt impedit. Quos dolorem dignissimos ad qui molestiae adipisci eaque. Sapiente repellendus pariatur impedit quidem officiis. Sapiente voluptatem dolor dicta saepe ipsam.", "Johnston" },
                    { new Guid("378918b8-4575-a5db-8dc2-1304f29aec08"), "Ismael", 30077229279L, "Nam dolore rerum fuga qui quos. Odio totam recusandae illum quaerat porro suscipit magni magnam. Voluptatem error dolore sequi corporis nihil alias sed. Quaerat possimus quam optio autem vel nobis. Explicabo laudantium enim quibusdam blanditiis est consequatur. Sint qui quis occaecati quia veritatis ipsa laudantium.", "O'Connell" },
                    { new Guid("3b31457a-0558-23aa-60a9-eebb3d6c8965"), "Rosemary", 1028310737L, "Et maxime quo voluptatum assumenda ipsum aperiam sunt. Aliquid dolores libero cupiditate eos. Voluptatem aliquid aliquam numquam non reprehenderit voluptate molestiae veniam et. Quia asperiores facilis est voluptatum mollitia accusamus minima. A et laudantium tempora qui sint suscipit.", "Blick" },
                    { new Guid("3fa93e29-bcff-e3ad-ed1d-9eb132579871"), "Janessa", 4015738621L, "Atque quo illum voluptatem dolores minus et. Magni odit est doloribus dicta. Impedit vero magnam aspernatur expedita assumenda commodi sit sequi magnam. Numquam fuga doloribus.", "Will" },
                    { new Guid("40e69560-8254-5db8-340e-ce0e90262226"), "Misty", 1056547416L, "Delectus in mollitia. Exercitationem ratione labore rerum perspiciatis necessitatibus quo. Eveniet ut ut aut amet at accusantium odit sed eius.", "Cronin" },
                    { new Guid("42d9d154-2f0c-014c-acd2-3b580ad7e69c"), "Leonora", 18078525955L, "Deserunt iste sed ut sint. Modi aut impedit dolorem qui quidem voluptatem quo voluptas vel. Ea soluta aperiam excepturi eum dolorem magnam voluptates quasi ducimus. Ut nobis vel est. Molestias sit animi occaecati quaerat dolorum. Ipsam voluptatem porro.", "Crist" },
                    { new Guid("451a3cbd-03b6-3fc4-3965-89d16b04ac22"), "Dexter", 26019418242L, "Quia veritatis inventore. Debitis libero harum. Voluptatem ab consequuntur nihil dolores dolore ratione. Molestiae quam et voluptatum qui dolorem. Voluptatem ab reprehenderit qui necessitatibus consequatur.", "Collier" },
                    { new Guid("45248c37-0191-0854-0e9d-6a6b03096b32"), "Alivia", 7098616505L, "Enim in perferendis dolor sint illo. Minima vel est iste quia. Dolorum molestiae ut et voluptas voluptatem quas.", "Runolfsdottir" },
                    { new Guid("47f7e8a3-5bb0-0ba9-452c-24db8a912ed7"), "Ettie", 24057722432L, "Perspiciatis tenetur tempore omnis dolorem modi omnis dolor. Recusandae minus corporis pariatur repudiandae adipisci incidunt voluptatem. Sit et et culpa dolorem veniam sapiente maxime tempore.", "Ruecker" },
                    { new Guid("4811cfdb-22be-5707-597c-31a5302347ad"), "Collin", 10089506668L, "Illo deleniti sint et sed est esse expedita consectetur ut. In facilis ut. Ut ab libero rerum in culpa veritatis.", "Johnson" },
                    { new Guid("48a4fb46-368a-e688-4992-e7f63f2fee49"), "Diego", 9048844380L, "Debitis aut et ad officiis dolores sunt. Laboriosam perspiciatis quos sed dolorem voluptas illum dolorem numquam. Ut illum enim. Voluptatem itaque voluptates deserunt. Temporibus ab rem sapiente. Ut quia repellat.", "Hoeger" },
                    { new Guid("4af5ea6a-8c8b-133f-4b41-6b08d8c0d2a7"), "Mortimer", 12128711390L, "Dolorem harum debitis ut sapiente quis natus qui. Accusantium nemo qui asperiores debitis. Tenetur tempore aut vero fugiat. Labore omnis autem.", "Kulas" },
                    { new Guid("4cc92f6d-4c72-7a51-a830-591f98030afb"), "Elenor", 8117426808L, "Ad eos fugiat et aliquam a. Ut porro voluptas possimus animi esse neque. Consequuntur temporibus totam ab tempore eaque fuga adipisci.", "Wunsch" },
                    { new Guid("4d0a851d-6869-bbfb-035f-1988e16cab83"), "Lenora", 10108435327L, "Ducimus in dolores odio qui pariatur dicta ut quod. Aut quod quo odit similique expedita culpa. At facere dolorem et minus sit voluptatem assumenda nesciunt consequuntur. Et consequatur voluptatem qui quia et omnis et voluptas qui. Provident blanditiis aliquam.", "Kris" },
                    { new Guid("5098fd05-f6ba-7cfe-fef7-a561a42e6505"), "Laney", 13085723906L, "Voluptatem ea minima. Beatae atque aut deserunt non. In asperiores eaque tenetur at id occaecati suscipit voluptatem.", "Kutch" },
                    { new Guid("50f15f9c-c38a-5022-a934-2cd84a642ea8"), "Margarita", 21108330268L, "Accusamus dolores delectus labore quidem sit ea vel. Reiciendis ipsa fuga totam dolor odio debitis eos. Quo magni iure. Voluptate illum sed tempora sit. Totam aut aut non laborum et molestias amet maiores.", "Weimann" }
                });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[,]
                {
                    { new Guid("54213e1e-d450-c14a-6767-3afbf7d46613"), "Luisa", 28045420398L, "Modi commodi sunt et quo aut nulla. Laboriosam aut sed autem sint harum. Optio illo nisi.", "Kuhic" },
                    { new Guid("55948733-b1e0-f780-5b24-651b964e2578"), "Mae", 9106319054L, "Ab architecto blanditiis qui alias eos nemo ex veritatis. Ducimus dolorum dolores excepturi enim nulla. Vel voluptatibus id odio suscipit.", "Roob" },
                    { new Guid("58343fe0-23ae-ff7a-903c-f9ccd8f51c5b"), "Rose", 13127133594L, "Rem eum voluptatum assumenda repudiandae est. Delectus alias beatae. Suscipit recusandae rerum vero dolorem. Enim iure commodi voluptate dignissimos velit. Est praesentium aut eveniet eaque minus facilis.", "Schneider" },
                    { new Guid("5cc486aa-5e67-fe12-65b6-33268dda443c"), "Jerel", 20078837021L, "Iusto excepturi molestiae et molestias autem praesentium saepe dolores dolorum. Voluptatem voluptatem ut. Aliquam est recusandae facilis veniam quaerat deleniti. Quasi nesciunt cumque reprehenderit praesentium eum earum ea nihil omnis. Aspernatur dolorum quo corrupti veniam. Et qui hic voluptas porro debitis quam fugit ut.", "Dooley" },
                    { new Guid("5ddbe55c-cc0e-7b26-8079-03e3ea19a090"), "Franco", 31128209037L, "In nostrum rerum et consectetur. Voluptatibus enim aut magnam nesciunt. Qui vero cumque et. Blanditiis dolorem quas esse sequi et commodi et quaerat quia. Odio nemo perferendis tempora suscipit quam occaecati. Ut quam debitis ex voluptates.", "Turcotte" },
                    { new Guid("5ffe08ee-fb9d-ae12-289e-a8044cb6fa07"), "Bridgette", 19109736980L, "Ea iusto dicta illo esse debitis minus. Ad ratione voluptatem molestias quos. Rem quo nemo. Qui odio aut qui. Similique officiis sed eum nostrum non. Earum voluptate qui alias velit sed.", "Kemmer" },
                    { new Guid("62894796-9bd3-d803-3a74-1f08a04ffac9"), "Josiah", 10028441490L, "Doloribus recusandae libero animi. Facere est eius recusandae veritatis totam. Voluptatibus et aspernatur beatae alias qui amet nostrum adipisci quia.", "Beer" },
                    { new Guid("651abe2e-f529-0718-3d45-679744391fe7"), "Ida", 23119609399L, "Eum dolorum eaque. Veritatis molestiae excepturi nihil aut numquam repudiandae non. Minus dolorem voluptates. Sunt maiores temporibus ex sed omnis possimus impedit.", "Walker" },
                    { new Guid("77847d90-5c50-0cb5-9391-69461f9fe69b"), "Colton", 26078635508L, "Qui sit quae voluptatem vel voluptatem accusantium molestiae et. Accusamus expedita voluptatum eos sed et laboriosam quisquam officia voluptatem. Saepe exercitationem quaerat illo maxime ipsam hic iste maxime quos. Nihil quos voluptas sapiente quas eos. Nulla quae dolores error id autem est expedita inventore. Id rerum eum qui ab aut dolore.", "Wehner" },
                    { new Guid("789656cd-0a70-3f3e-a74a-523994e9702f"), "Rogelio", 25026501299L, "Aut velit perferendis et et nostrum laborum. Et exercitationem assumenda adipisci quaerat eveniet. Rem qui unde. Sint rerum molestiae quo sit expedita beatae.", "Jast" },
                    { new Guid("78a824bf-e969-9ed8-6fbd-109a1796eb3f"), "Madalyn", 12026007591L, "Dolorum doloremque voluptas possimus pariatur similique. Iusto laboriosam eos minima vel. Facere vel et dolores porro odio ex. Earum facilis numquam laborum voluptatem vitae aliquam illo qui omnis.", "Lemke" },
                    { new Guid("797bf62e-7046-ba45-ee71-01590323c03c"), "Benedict", 4105921670L, "Corporis dolor voluptas quia qui beatae nulla voluptatibus laborum. Suscipit voluptas aliquam nam consequuntur suscipit. Qui quo placeat commodi vero dolore soluta saepe in.", "Oberbrunner" },
                    { new Guid("7ae3279c-f737-5fdc-d89d-c70be96dfb0e"), "Reymundo", 16037841955L, "Fugiat ab ab dolor nobis consequatur. Numquam assumenda dolores explicabo esse. Quidem asperiores et totam cumque quia est praesentium in iste. Dicta fuga vel praesentium temporibus. Nostrum nihil corporis magni reiciendis sed quam laudantium.", "Little" },
                    { new Guid("7cba8676-e562-3619-8ccd-eb943e76cd20"), "Saul", 9067830781L, "Nulla et assumenda et vero excepturi ipsam. Est iure tempora minus sit. Provident est in voluptatum voluptas molestiae earum exercitationem. Et minus enim voluptate minus veniam id culpa. Est consequuntur est sequi ea dolorum. Quos sit totam maiores quia cumque inventore fugit expedita ducimus.", "Boehm" },
                    { new Guid("7cbeda6a-d714-e3e1-260a-8288a333960a"), "Ben", 24049741983L, "Ut reiciendis voluptatibus amet exercitationem veritatis. Earum veniam totam recusandae iusto illum esse inventore voluptatem. Ut eum tenetur dignissimos eum omnis unde blanditiis nisi molestiae.", "Zieme" },
                    { new Guid("82df0ad0-6e88-f132-343c-5e7ffcf86273"), "Anjali", 8086532833L, "Consequuntur autem praesentium. Sit quia non sapiente consequatur. Dolores ullam atque modi dolorem quam praesentium nisi necessitatibus. Vero ad illo ipsa veniam quia dolor quas iste est. Animi ipsum nisi id voluptate odit eos eaque sequi. Consequuntur ipsam ipsa id exercitationem molestiae officia ex.", "Dibbert" },
                    { new Guid("85c44db4-ba4f-973e-5fba-658e675649ea"), "Destinee", 18018026623L, "Veniam eligendi aperiam fuga rerum quam quis animi hic eaque. Alias qui enim debitis rem officia. Asperiores et maiores est dolor voluptatem omnis. Voluptatem ut dolor. Dignissimos quaerat ut ea totam. Et eum voluptas ut dolorem.", "Ernser" },
                    { new Guid("88829011-0e15-70e1-6257-99690c7e537d"), "Jocelyn", 1115502790L, "Ut id minima. Rem minima qui eius et quam. Rerum nulla similique.", "Mayer" },
                    { new Guid("88a53bee-98fc-b13c-fbbf-73c98706521d"), "Henri", 5087447792L, "Possimus quasi similique atque. Soluta dolore ab fuga qui. Eveniet eos non ducimus.", "Bergnaum" },
                    { new Guid("8cf67a48-a5bc-f22e-37a1-89b7d937d9ce"), "Arielle", 9105932593L, "Officia aut consequuntur voluptatem laborum amet sed. Eos ex qui perferendis aliquam. Reiciendis et assumenda pariatur officiis expedita aut qui necessitatibus. Quam adipisci error qui et voluptatem at repellat illum.", "Schumm" },
                    { new Guid("914fe38f-4b86-2799-8502-4fea872cae4e"), "Tressie", 29095247944L, "Ut occaecati voluptatum impedit quisquam minima quia sint. Sit nihil saepe. Aliquam dolorem eius. Nesciunt enim consectetur.", "Tremblay" },
                    { new Guid("928f7d45-a546-69e6-f892-242aca8041a5"), "Isadore", 25108206228L, "Aut dolore voluptas est itaque. Qui totam nostrum commodi sit laborum. Aut suscipit ut earum. Magnam hic fugit laudantium dolores natus accusantium et. Sunt beatae dicta.", "Jakubowski" },
                    { new Guid("9425acca-fae3-f2f7-f351-04152dbddf02"), "Marcelo", 29037846234L, "A et esse nam. Vel voluptatem similique quas distinctio dolores quia ad. Ullam aliquid vel rerum culpa assumenda et. Voluptate alias harum quo reprehenderit et. Ea iusto occaecati aliquam inventore. Rerum dolores culpa.", "Torphy" },
                    { new Guid("94f6c15c-69c2-62f7-a85a-e15f89a5a335"), "Herman", 24127718632L, "Officia dolores consequatur. Sit velit cupiditate asperiores eum quis est ea voluptas. Autem veritatis omnis neque. Eum assumenda veniam voluptate earum dolor quis et perspiciatis. Quidem magni consectetur ut qui.", "Bode" },
                    { new Guid("9add8ba0-71e1-72c6-d330-3d2e67a4a851"), "Violet", 3086525347L, "Esse nulla enim. Repellat culpa mollitia ea veritatis similique voluptates aperiam debitis aut. Minima et quisquam pariatur itaque consectetur debitis itaque. Sed quidem qui sint ex fuga delectus.", "Kuphal" },
                    { new Guid("9b262105-742a-e327-1506-6f85852dcd3e"), "Hardy", 7126023477L, "Asperiores ea culpa. Est soluta quia molestiae quam mollitia rerum minima consectetur laudantium. Autem impedit laboriosam quaerat illo ut vero nulla. Recusandae odio alias repellat amet porro quo voluptatem. Ut saepe voluptatem nobis distinctio rerum quam quia dolor error.", "Morissette" },
                    { new Guid("9db141a8-3ef7-69cf-3c4a-613bee8f0376"), "Pinkie", 21039500504L, "Voluptatem adipisci ut placeat rerum ad. Et eveniet blanditiis eos dolorum ab animi. Ut quia accusamus aliquid libero quasi possimus. Nemo consectetur odio. Fuga et provident. Dolores nobis in.", "Hermiston" },
                    { new Guid("a02c9af2-f415-0062-f16f-9dae59c514de"), "Alan", 25117027662L, "Dicta praesentium in numquam laboriosam et sed fuga unde est. Ullam atque ut incidunt quia facere. Id ducimus quia quia cum necessitatibus debitis sed dolorem dolor. Temporibus nobis non ut.", "McDermott" },
                    { new Guid("a093c4fd-5e06-8078-fc0d-77b9a785da4d"), "Sheridan", 13015921492L, "Unde culpa consequatur dolorem iusto dicta mollitia qui similique. Nisi sit omnis nihil enim ullam sint repudiandae sequi ut. Voluptatem odit error et.", "Wisozk" },
                    { new Guid("a165c6c4-4ecc-5c9f-4b4b-035077e2dd4c"), "Rosalinda", 20069522743L, "Et aliquid odio repudiandae nesciunt veritatis iure consequuntur. Ducimus earum ducimus minima nam consequatur. Consectetur maiores magnam natus. Cupiditate aut sunt ducimus illum ipsa.", "Bergnaum" },
                    { new Guid("a63654a9-94fe-4152-3c5c-1906707e1cdd"), "Graciela", 12057744268L, "Est sint et sequi totam soluta. Autem dolore tempore et. Ad praesentium nostrum quidem repellat numquam perspiciatis aut dolorem. Eum quia atque at quia laudantium praesentium aperiam. Eum voluptate qui minima quo vitae minus quo porro aut. Culpa voluptates doloribus maxime ut.", "Hudson" },
                    { new Guid("aaf21221-47af-b7fd-79d7-0032ee5cb28f"), "Isac", 14029411639L, "Autem aut et nihil. Odit voluptatum iste autem sunt autem. Rerum eaque aut accusamus quod facilis qui. Velit ullam vel minus.", "Goodwin" },
                    { new Guid("aec3b2d7-0179-2493-10b3-9f57e88c1746"), "Edwina", 19038433027L, "Optio in voluptas illo. Reiciendis nisi consequatur. Est repellendus consequatur inventore in. Molestiae voluptatibus maiores. Ea laudantium perspiciatis est est. Ut quisquam totam accusantium et iste temporibus vel quod.", "Osinski" },
                    { new Guid("b1b52ac8-e6f0-3fba-04ca-0101335b173e"), "Maida", 28085243146L, "Quae velit enim labore recusandae. Quia cum nisi veritatis nulla. Aut dolores excepturi qui est fugiat et quidem.", "Barton" },
                    { new Guid("b456d685-f97b-b753-8d88-bf03ec7d21e0"), "Jazmin", 31088604469L, "Porro et distinctio minus sunt enim est temporibus voluptatibus nihil. Rerum ut modi ut. Harum odit aut saepe nam et ut sint. Eum accusamus fugit est nihil molestiae. Molestias officiis id dolor praesentium. Voluptate magni ullam.", "Hackett" },
                    { new Guid("b45dfa91-d1e5-5244-8eb9-98e718ff86be"), "Cali", 24038619485L, "Amet rerum et ut dignissimos. Velit cupiditate saepe libero necessitatibus inventore. Sed esse mollitia deserunt dignissimos ratione. Qui in commodi unde dolor vitae. Modi tenetur magni qui nemo consequatur. Dignissimos expedita velit repellat fugiat dolor id libero esse.", "Goldner" },
                    { new Guid("b7a6eae2-14a9-3df6-d6e4-f863a24bb7fd"), "Jason", 2065638692L, "Ea voluptatibus ipsum reprehenderit. Aperiam molestias minima eveniet dolor nesciunt inventore dolor. Alias non et autem quae ducimus. Est explicabo nobis fugit quaerat. Quos veritatis dolores officiis minima optio quod beatae sit magni.", "Collins" },
                    { new Guid("b801cdda-e5ec-5667-3f6f-04a82b04c978"), "Adalberto", 16047616801L, "Id quam voluptatibus natus rerum vel excepturi. Eveniet repudiandae ex delectus. Dolores et enim eum reiciendis. A velit nihil est magnam qui aut nobis molestiae nihil.", "Klein" },
                    { new Guid("bb547d13-048d-384e-e3b2-683a6e599227"), "Jamaal", 10085930856L, "Expedita voluptatem praesentium maxime quas. Numquam nam est. Quis beatae veniam at aperiam minus dolore doloribus doloribus. Numquam atque nisi magnam tenetur nemo qui. Non aperiam et in accusantium.", "Baumbach" },
                    { new Guid("bfa064a8-df3d-19d9-203e-46bea13ed77b"), "Olen", 13126321877L, "Eius et dolorem rerum. Nobis itaque provident dolores et modi ut. Dolore dolor magni ut quasi debitis doloremque at unde. Impedit est quia dicta facere autem voluptatem reprehenderit. Temporibus rerum amet. Commodi quos et rerum doloremque quisquam enim.", "Stiedemann" },
                    { new Guid("bff43112-052e-6448-e675-8985015eaf89"), "Angelo", 2066528637L, "Qui ea sunt earum aspernatur rerum dolor. Eligendi dolor blanditiis aut. Id consequatur quis veritatis qui ut iusto accusamus.", "D'Amore" },
                    { new Guid("c1bdad9a-9258-9b3f-f16c-706a2733f3ed"), "Dane", 29086235747L, "Occaecati labore ut quam fugit. Libero eligendi quis sint maiores. Nihil aperiam debitis qui et sequi culpa dolor. Minima possimus recusandae ullam quibusdam aspernatur dolor sed eaque dignissimos. Aliquam non suscipit. Est earum deserunt maiores dicta et quod illum consequatur.", "Morissette" }
                });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[,]
                {
                    { new Guid("c44febfe-cc0d-18d5-bd28-32c910aa695c"), "Meaghan", 8106627453L, "Recusandae saepe aut facere magnam. Neque soluta omnis voluptatibus perspiciatis expedita dolores expedita. Quisquam vero expedita et saepe ad vel. Molestiae possimus amet et quo magni quidem illum eos.", "Bode" },
                    { new Guid("c83e9741-5b89-ffb2-48e2-f95fbf847aeb"), "Burdette", 12086439776L, "Culpa voluptas sint qui qui est. Fugit perspiciatis consequatur sunt fugit vero quam eligendi non. Impedit dolores molestiae libero et voluptatem qui minima dolor libero. Molestiae in beatae animi voluptate sint omnis. Doloribus mollitia et alias debitis aspernatur consectetur velit est. Ut velit reprehenderit autem fuga sit voluptatibus eum non quod.", "Marquardt" },
                    { new Guid("c975fced-537c-3ae8-708c-ad3700b8e2ae"), "Kameron", 26127634199L, "Eum accusamus saepe quia consequatur omnis eveniet itaque voluptas molestiae. Eos voluptatum optio enim laboriosam ducimus. Voluptatem error tempora voluptate nesciunt rerum repellendus numquam quas maiores. Non voluptates ut officia magni voluptatem in aut dolorem.", "Leannon" },
                    { new Guid("cb24aed9-7fd8-7129-965c-752b7d961567"), "Harley", 30107415749L, "Necessitatibus fugiat nesciunt nam voluptatem. Repudiandae ullam tenetur pariatur mollitia magnam. Et et omnis odit doloremque nam et repellat dolores.", "Smitham" },
                    { new Guid("cc08ba47-736f-1ff2-5830-eb5e3729cf59"), "Audreanne", 30118433358L, "Ad minima alias atque. Rerum rerum officiis. Reprehenderit quo nesciunt quasi expedita. Alias asperiores est incidunt voluptatem excepturi nulla. Distinctio aut ut ad. Consequatur eius deleniti consequatur consequatur autem a.", "Dietrich" },
                    { new Guid("ce598468-e8b1-7148-a800-5e3959e7ae47"), "Clementina", 16115513412L, "Aut numquam commodi rerum ea fugiat. Consectetur cumque qui incidunt quos. Illum ut vitae vitae asperiores. Ipsum iste facilis voluptates.", "Deckow" },
                    { new Guid("d213d41a-5ff2-7f02-d729-bb151996e8f1"), "Sharon", 4099701930L, "Dolores non quis rerum dolor dolor atque numquam et. Libero cupiditate dolorem eligendi. Laboriosam fugiat et excepturi quam dignissimos nobis molestiae sit.", "Luettgen" },
                    { new Guid("d57087d5-2a1c-5d02-4cb0-458c11940d1e"), "Ryan", 13089134255L, "Ratione tempora eum nulla repudiandae dolorem vero quo. Sint dolorem quisquam. Et officia labore. Asperiores illo commodi inventore aperiam qui cumque quaerat dolores. Culpa odio dolores facilis.", "Mayer" },
                    { new Guid("d6e88edb-3b1f-c53c-6a79-beb87f81cfbe"), "Emmett", 15116933249L, "Nobis doloribus est deleniti non. Recusandae consequatur debitis aliquam numquam. Placeat nam adipisci voluptatem qui recusandae ea vero.", "VonRueden" },
                    { new Guid("d7e385f2-c31f-fc32-d513-48d979bc1026"), "Wilfredo", 2016202676L, "Qui sunt quae omnis numquam corrupti. Magnam ut magnam est fugit maxime voluptatem repellendus iusto perspiciatis. Est dolor aut dolorum fugit aliquam. Eum sequi dignissimos sint fuga. Veritatis earum alias perspiciatis et velit.", "McClure" },
                    { new Guid("dbbf9d6a-c736-a19b-20e7-0f577c9f4908"), "Kristian", 21079421291L, "Quibusdam distinctio nobis mollitia. Fugit voluptatum reiciendis. Aspernatur odio mollitia animi deleniti. Sit sint in veritatis ducimus minima quia asperiores vel. In doloribus alias impedit et magni. Error voluptas consequuntur earum sunt eaque velit.", "Streich" },
                    { new Guid("dd0df600-78c3-77fe-4ffa-6a170c15edc6"), "Carlo", 4126644375L, "Sed vero voluptatem quibusdam explicabo incidunt asperiores blanditiis aut. Aut distinctio quo dolorem dolorum sint quos voluptatem. Odit earum nihil sint et qui magni.", "Mohr" },
                    { new Guid("dd674b74-a446-338e-95ad-1d067b9002d8"), "Lisette", 5125649191L, "Quia voluptas voluptas nemo totam cum quia et. Id laboriosam voluptatem mollitia ab ut blanditiis est molestiae. Et ipsum tenetur similique ut. Ducimus in tenetur error debitis laborum cupiditate. Quisquam et error consequatur quia ad et perferendis saepe enim. Voluptatem ipsam est tempore sed est ut.", "Kunde" },
                    { new Guid("def09a7c-83e8-81f8-c294-7bc4a87b333e"), "Jean", 7036243567L, "Pariatur voluptatem quo magnam. Molestias quibusdam minus voluptatem. Eveniet laudantium consectetur fugit molestiae quia fuga.", "Jast" },
                    { new Guid("e396c0db-7d2a-01ca-fddf-789867ec4a59"), "Alize", 20086035945L, "Est maiores omnis qui laboriosam qui. Voluptatem repellat est saepe officia inventore officia facilis doloremque. Voluptatum suscipit sapiente natus sed ut accusantium. Animi animi quo et rerum error. Sit iste pariatur aspernatur.", "Ritchie" },
                    { new Guid("e5e53642-6554-70f2-f66b-7425857bf463"), "Jessika", 16025732980L, "Ipsum iusto sit animi voluptatem voluptatum. Ratione odit corrupti possimus. Et et aspernatur commodi sit veritatis quod debitis sed et. Omnis dolor expedita. Nihil maxime voluptatem voluptas. Ea nostrum consequatur ex veritatis consequatur quo aut.", "Jenkins" },
                    { new Guid("e627437d-8cde-1ea4-9ec9-52df31c92ff0"), "Mike", 20037945782L, "Earum iste et ut dolores nisi et aut. In excepturi porro. Ipsum optio qui. Aperiam molestias debitis. Sed sint optio quisquam corrupti ut quasi nemo sint. Ut sint veritatis minima qui.", "Littel" },
                    { new Guid("e936f9c3-d6ee-0788-4e7d-4e52f8168c60"), "Wade", 25086740519L, "Sint dolores iure dolorem deleniti. Vero sit ea. Fugit qui repellat quaerat placeat. Ad voluptatem facere ea occaecati ut omnis corporis debitis eum. Voluptates ut architecto. Dicta qui sed.", "Parker" },
                    { new Guid("ea35527f-7265-0f61-f57b-dda825362235"), "Nash", 31017016892L, "Nihil harum magni temporibus odit molestias. Ducimus aspernatur placeat qui ut voluptatem autem ut fuga. Perspiciatis laboriosam id odio laborum facere sunt optio.", "Mante" },
                    { new Guid("f245ca9e-ecfa-020b-b012-9efb6bccefe3"), "Eusebio", 9058019302L, "Qui sit facilis est nisi harum dignissimos dolores fugiat. Et aut dicta. Est similique similique aut in quasi. Eos tenetur nobis suscipit culpa architecto.", "Prosacco" },
                    { new Guid("f7d26fb6-ee4d-782a-7b80-7573f80de0b6"), "Christelle", 25047902730L, "Aliquam voluptatibus aperiam. Animi et ut quod. Eaque blanditiis dignissimos. Possimus cum non. Dolorem nam qui sed dicta ex. Explicabo soluta nemo labore ipsa perferendis.", "Crona" },
                    { new Guid("f879c595-896c-90a2-022a-fb172cf57b79"), "Gonzalo", 5066616187L, "Voluptatem sapiente nulla officiis quis omnis rerum voluptate ad. Architecto commodi quam nostrum ut sed qui tenetur accusantium. Et optio sed est ea perferendis voluptates fugiat minus vel. Quae labore nihil itaque ullam qui enim error in.", "Littel" },
                    { new Guid("f9ac5974-83b5-0c51-baa5-113796491151"), "Patsy", 15018102509L, "Praesentium fuga est commodi eum dolor. Nihil earum quod. Aut qui perspiciatis blanditiis quasi. Velit quia excepturi voluptas et eius veritatis minima sapiente. Quidem dolorem ab et eos. Quam tenetur animi.", "Huels" },
                    { new Guid("ff7db10a-3614-8fef-f65b-d17278ddd2f5"), "Beulah", 2078933723L, "Temporibus rem incidunt. Deserunt enim nihil explicabo voluptatem adipisci commodi ipsa possimus quibusdam. Tenetur non omnis eos placeat et.", "Paucek" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "PaymentTypeName" },
                values: new object[,]
                {
                    { new Guid("39213ef8-2a76-4ea5-93bb-db091d1ae647"), "Sularaha" },
                    { new Guid("c52c5ec7-1cc8-4854-b6a8-c2137dda714e"), "Kaardimakse" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_BusinessUserId",
                table: "Participations",
                column: "BusinessUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_EventId",
                table: "Participations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_IndividualUserId",
                table: "Participations",
                column: "IndividualUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_PaymentTypeId",
                table: "Participations",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "BusinessUsers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "IndividualUsers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");
        }
    }
}
