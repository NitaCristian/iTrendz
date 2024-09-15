using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iTrendz.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Domain", "Email", "EmailConfirmed", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, 0, "81b8d14e-743f-4d66-8524-bc0fd1a1cc5f", "Animi accusantium excepturi molestias.", "Lifestyle", "Jimmy.Cruickshank70@hotmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/645.jpg", false, null, "JIMMY.CRUICKSHANK70@HOTMAIL.COM", "ELMORE.HYATT5", "xDuRkzbnlY", "(526) 795-4991 x033", false, "ghzjhdihaafnogjmxbxxqokovdbikcvv", new DateTime(2024, 10, 18, 19, 36, 18, 880, DateTimeKind.Local).AddTicks(5049), null, false, "Elmore.Hyatt5", "Brand", "https://otilia.biz" },
                    { 2, 0, "5786ee54-c51f-434d-8366-7406a678ab15", "Molestias qui veniam excepturi voluptatum eos ut officia.", "Entertainment", "Felipe60@yahoo.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1054.jpg", false, null, "FELIPE60@YAHOO.COM", "MELVIN38", "K7MSXs00mN", "818.208.0108 x641", false, "dztbzzusczrqamoofjlftahjnxphyrkb", new DateTime(2024, 11, 25, 23, 45, 25, 80, DateTimeKind.Local).AddTicks(9365), null, false, "Melvin38", "Brand", "http://ryan.com" },
                    { 3, 0, "02790817-d579-4c51-835f-585fadb62aa2", "In eveniet occaecati consequatur distinctio.", "Fashion", "Arvilla_Veum42@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1217.jpg", false, null, "ARVILLA_VEUM42@GMAIL.COM", "MAGDALEN_GERHOLD", "6WjZgG4zWU", "1-298-248-8143 x3806", false, "qhmlmojkjaxprobhbmluucghroimetzq", new DateTime(2024, 10, 6, 19, 56, 4, 64, DateTimeKind.Local).AddTicks(5799), null, false, "Magdalen_Gerhold", "Brand", "https://dante.com" },
                    { 4, 0, "a50c72da-73fe-4e2b-9252-78252a0bd6ca", "Laboriosam sed enim officia eos minima qui.", "Lifestyle", "Johan.Olson81@hotmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/369.jpg", false, null, "JOHAN.OLSON81@HOTMAIL.COM", "EUGENE.CHAMPLIN83", "skwnGnftbj", "1-844-549-4538", false, "fsucokbfhyfphmljdxfhogdkubiuiwgq", new DateTime(2025, 5, 27, 16, 50, 1, 633, DateTimeKind.Local).AddTicks(9403), null, false, "Eugene.Champlin83", "Brand", "https://bridgette.com" },
                    { 5, 0, "9af944f3-f681-4967-b9fe-adfc815aaaba", "Rerum esse debitis accusamus beatae quas.", "Health", "Michaela_Kunze78@hotmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/435.jpg", false, null, "MICHAELA_KUNZE78@HOTMAIL.COM", "MAYBELL22", "Daac7NnOmM", "(290) 523-7741 x13969", false, "qwktdslbslqnevhtgmzcsfseyfncddsv", new DateTime(2024, 10, 25, 5, 5, 29, 708, DateTimeKind.Local).AddTicks(6943), null, false, "Maybell22", "Brand", "http://marvin.net" },
                    { 6, 0, "0a66f2d2-81f0-416e-a267-6f7f6c1eebe2", "Temporibus perferendis aut asperiores.", "Health", "Gertrude.Smitham@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1000.jpg", false, null, "GERTRUDE.SMITHAM@GMAIL.COM", "ROEL42", "c0W0MB8b8X", "(367) 676-3221 x51967", false, "qdwyxaovpepelaouzvrdhmutmujiwalg", new DateTime(2025, 5, 18, 16, 33, 14, 475, DateTimeKind.Local).AddTicks(2820), null, false, "Roel42", "Brand", "https://arthur.net" },
                    { 7, 0, "d6449fd5-12f0-4c42-94eb-f00e728aa2e7", "Saepe dolores veniam aut animi aliquid quam.", "Sports", "Sadie15@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/303.jpg", false, null, "SADIE15@GMAIL.COM", "ALESSANDRA_TOY16", "lbZvYk0F1a", "(414) 533-2706", false, "dptgsepfdfdqnotuwqivgazpdhvhbhrl", new DateTime(2025, 7, 23, 7, 49, 12, 287, DateTimeKind.Local).AddTicks(2349), null, false, "Alessandra_Toy16", "Brand", "http://vince.org" },
                    { 8, 0, "ab76ebf8-97c3-4252-a061-f3e8b888a23e", "Et consequuntur aut expedita nihil expedita deleniti sapiente nisi rerum.", "Lifestyle", "Velda_Rice@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/929.jpg", false, null, "VELDA_RICE@GMAIL.COM", "DARION.JOHNSON", "Vm03_vXDXk", "416.538.1013 x68919", false, "ffudrpytgknuhrkrxkwwdxultlivokxq", new DateTime(2024, 10, 15, 11, 1, 7, 104, DateTimeKind.Local).AddTicks(6308), null, false, "Darion.Johnson", "Brand", "http://peter.com" },
                    { 9, 0, "c9440f4b-7a1a-4233-8bcd-cf094df95b94", "Sed magnam numquam ut.", "Entertainment", "Barrett40@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/70.jpg", false, null, "BARRETT40@GMAIL.COM", "ELTA_SCHINNER", "Z6HLADtQCF", "425.289.7002 x62769", false, "thpkcslzosgjnapqckjtzaupsvarynxm", new DateTime(2024, 9, 28, 14, 54, 8, 428, DateTimeKind.Local).AddTicks(6130), null, false, "Elta_Schinner", "Brand", "http://corrine.name" },
                    { 10, 0, "6852d85c-da84-44fa-bb0f-cc825cc74780", "Commodi exercitationem quibusdam aperiam aliquid.", "Sports", "Eda.Upton@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1243.jpg", false, null, "EDA.UPTON@GMAIL.COM", "VICTORIA70", "npG8KL_xIo", "(406) 745-6713 x83955", false, "desoomrqfvkppmgltzwdhkxbjhzkidyx", new DateTime(2024, 10, 14, 5, 47, 31, 270, DateTimeKind.Local).AddTicks(4672), null, false, "Victoria70", "Brand", "https://yvonne.net" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Domain", "Email", "EmailConfirmed", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Price", "Rating", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteUrl" },
                values: new object[,]
                {
                    { 11, 0, "f49e3f8e-9ef3-48e4-ab23-fcd954ba4010", "Reprehenderit esse consequatur facilis quia necessitatibus dignissimos.", "Fashion", "Leopoldo96@hotmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/356.jpg", false, null, "LEOPOLDO96@HOTMAIL.COM", "ARLENE.MULLER", "VP1pV7zG51", "1-722-287-8707 x308", false, 6433, 5, "jygyisfgqqxlkukluzvwbyxonzknlgkz", new DateTime(2025, 6, 25, 5, 40, 9, 222, DateTimeKind.Local).AddTicks(9965), null, false, "Arlene.Muller", "Influencer", "http://letha.info" },
                    { 12, 0, "f16686bd-db87-4a75-b2f3-268783ff1a7e", "Perspiciatis dolores hic rerum id iusto veniam aperiam voluptatem.", "Tech", "Jason91@hotmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/348.jpg", false, null, "JASON91@HOTMAIL.COM", "NICKLAUS.VON", "uZ9JKV5vSD", "535.522.7064 x52074", false, 5090, 2, "vmuntkmoutiycdluinajrttrwecawvoq", new DateTime(2024, 11, 22, 1, 3, 16, 57, DateTimeKind.Local).AddTicks(1134), null, false, "Nicklaus.Von", "Influencer", "http://genesis.biz" },
                    { 13, 0, "5f764e23-d810-4103-b2e6-f10ac969304f", "Ad quod voluptatum.", "Lifestyle", "Hans_Thompson@hotmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/139.jpg", false, null, "HANS_THOMPSON@HOTMAIL.COM", "ELISSA_PFANNERSTILL66", "b9_afTEJP0", "776.205.8228", false, 6155, 3, "svnjutqjmagflpvsmyaodswcnbqmfaqz", new DateTime(2024, 10, 11, 19, 10, 18, 301, DateTimeKind.Local).AddTicks(9079), null, false, "Elissa_Pfannerstill66", "Influencer", "https://lacy.name" },
                    { 14, 0, "65c3a4de-47e4-47ad-a0c6-61428eb0d72b", "Mollitia laboriosam consectetur officia eos ex quos nemo impedit sapiente.", "Lifestyle", "Karen.Hirthe94@hotmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/755.jpg", false, null, "KAREN.HIRTHE94@HOTMAIL.COM", "CLOYD.KUPHAL80", "RODmqgBygZ", "800-981-7605", false, 4397, 3, "frxuwjpsyijhetjjrnxdpvppiycjbgtm", new DateTime(2024, 10, 15, 5, 57, 52, 29, DateTimeKind.Local).AddTicks(93), null, false, "Cloyd.Kuphal80", "Influencer", "https://robin.com" },
                    { 15, 0, "0e2256bb-95b3-43f3-bf24-90c492eba80c", "Ut qui aliquam nisi.", "Entertainment", "Kyra_Hahn53@yahoo.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/825.jpg", false, null, "KYRA_HAHN53@YAHOO.COM", "LAZARO_DAVIS", "wUKSL2BQO1", "1-260-304-2077", false, 6883, 3, "ohwzelownayjjlcegvoskarvuammrifr", new DateTime(2025, 7, 25, 1, 2, 46, 484, DateTimeKind.Local).AddTicks(6743), null, false, "Lazaro_Davis", "Influencer", "https://verner.biz" },
                    { 16, 0, "13a64e2d-2d55-4115-a585-9d6e1cc1a975", "Dolores nihil non corporis pariatur perferendis.", "Fashion", "Leonie59@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/169.jpg", false, null, "LEONIE59@GMAIL.COM", "HARMON21", "0oFoIcnp9m", "1-881-340-2144 x769", false, 5780, 4, "midmyapkjdnymjgwvefafbnbcwzeqsqt", new DateTime(2025, 4, 20, 9, 8, 16, 43, DateTimeKind.Local).AddTicks(8414), null, false, "Harmon21", "Influencer", "https://evie.com" },
                    { 17, 0, "02070eaa-7d2e-483e-9618-2b5dff04a031", "Ipsum delectus vero pariatur deleniti quia ut ducimus.", "Entertainment", "Dayton.Cremin@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1029.jpg", false, null, "DAYTON.CREMIN@GMAIL.COM", "WEBSTER88", "32NUV3aQNI", "1-358-669-1401", false, 3490, 4, "qlbhvfzhrehiyxbqmfbrldsstopttsde", new DateTime(2025, 1, 30, 18, 31, 31, 425, DateTimeKind.Local).AddTicks(7478), null, false, "Webster88", "Influencer", "https://kaitlin.biz" },
                    { 18, 0, "ffa9ba2f-aa1e-4228-8f6e-c0abeaf6c483", "Aperiam quis cum autem adipisci ut harum.", "Sports", "Nora_Johnston@yahoo.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/791.jpg", false, null, "NORA_JOHNSTON@YAHOO.COM", "BRITNEY_JOHNS", "FzU3xSTrky", "667.407.0509 x346", false, 5347, 4, "ijnswluvezosozxrvbdatfzvvhxmywtz", new DateTime(2025, 8, 16, 1, 44, 8, 524, DateTimeKind.Local).AddTicks(1780), null, false, "Britney_Johns", "Influencer", "http://zoey.biz" },
                    { 19, 0, "54edc62e-ee1c-47a9-a58e-594b048e8285", "Rem quas impedit reprehenderit quaerat sit.", "Entertainment", "Delbert_Wisoky76@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1111.jpg", false, null, "DELBERT_WISOKY76@GMAIL.COM", "ABIGAYLE89", "lVzWw4tHaL", "648-436-4141", false, 5095, 3, "qgeiitpfgecvprfbvqrnrqjvsyhnevxn", new DateTime(2025, 9, 12, 13, 18, 47, 296, DateTimeKind.Local).AddTicks(1180), null, false, "Abigayle89", "Influencer", "https://jarvis.info" },
                    { 20, 0, "0bd83270-a023-4f57-a3a3-9f74cbdcd3bc", "Laudantium cupiditate omnis nisi et dolor quidem tempore.", "Tech", "Myah41@gmail.com", false, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/267.jpg", false, null, "MYAH41@GMAIL.COM", "ALYCE2", "ktIW6_j2Us", "(923) 645-2694 x426", false, 9825, 1, "cslkibdkzxlmderodrywvmssmofhvjok", new DateTime(2025, 2, 3, 16, 54, 49, 902, DateTimeKind.Local).AddTicks(1674), null, false, "Alyce2", "Influencer", "https://mertie.name" }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "AllocatedBudget", "BrandId", "DateTime", "Description", "ImageURL", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1, 2681.7199999999998, 3, new DateOnly(2025, 1, 10), "Est quam aliquam ullam amet occaecati rerum ut inventore. Aut et earum veniam numquam dolorem harum. Ut optio quidem repudiandae repudiandae.", "https://picsum.photos/640/480/?image=958", new DateOnly(2023, 9, 26), "Unbranded Granite Cheese" },
                    { 2, 2598.0500000000002, 1, new DateOnly(2025, 2, 21), "Asperiores sapiente perferendis quisquam incidunt beatae dolor ipsum. Vel esse distinctio non ut impedit. Modi corrupti est omnis tempora laborum. Consequatur dolores vitae veniam. Quia sit sequi et aliquid laboriosam hic itaque ipsa non.", "https://picsum.photos/640/480/?image=295", new DateOnly(2023, 10, 6), "Tasty Cotton Shirt" },
                    { 3, 1520.52, 8, new DateOnly(2025, 2, 4), "Quaerat velit tempora cupiditate quis beatae. Quisquam esse qui optio libero explicabo voluptas est totam. Ut nihil eos esse praesentium. Culpa aspernatur ipsum at unde sed ut earum velit. Quia delectus odit blanditiis ut facilis.", "https://picsum.photos/640/480/?image=829", new DateOnly(2023, 11, 19), "Handmade Granite Salad" },
                    { 4, 2932.6599999999999, 7, new DateOnly(2025, 5, 8), "Unde officia odit aut. Aut vero perspiciatis tenetur et quam pariatur delectus voluptates ea. Tempore est totam et culpa explicabo et labore. Magni eum sed placeat aut sed a. Et voluptatem rerum consectetur eius fugit doloribus amet dolor qui.", "https://picsum.photos/640/480/?image=945", new DateOnly(2023, 11, 1), "Handcrafted Fresh Chips" },
                    { 5, 2785.6599999999999, 9, new DateOnly(2024, 10, 22), "Eos dolor est error nulla. Velit voluptatum aliquam sed distinctio suscipit aut est. Voluptates blanditiis fugit non laboriosam. Qui quo voluptatum veritatis ut. Consequuntur id dolore ex id eos molestiae suscipit.", "https://picsum.photos/640/480/?image=326", new DateOnly(2023, 10, 16), "Fantastic Soft Keyboard" },
                    { 6, 1094.26, 8, new DateOnly(2025, 8, 12), "Voluptatum illum velit et voluptas sint ipsam. Doloribus quod vel sunt est aspernatur laboriosam. Non placeat qui. Nesciunt animi veniam et consequatur. Dolor facere dignissimos quia nihil esse.", "https://picsum.photos/640/480/?image=259", new DateOnly(2024, 8, 5), "Unbranded Wooden Bacon" },
                    { 7, 2783.3499999999999, 10, new DateOnly(2025, 6, 13), "Itaque at harum alias. Eos et similique. Voluptatum tenetur magni autem aut error reiciendis.", "https://picsum.photos/640/480/?image=706", new DateOnly(2024, 3, 20), "Small Metal Computer" },
                    { 8, 4963.8800000000001, 10, new DateOnly(2025, 4, 10), "Eos tempore sint deleniti. Sed eum qui. Nulla quis veniam aperiam sit velit animi cum voluptates.", "https://picsum.photos/640/480/?image=432", new DateOnly(2024, 7, 14), "Licensed Frozen Towels" },
                    { 9, 4027.8200000000002, 10, new DateOnly(2025, 3, 30), "Porro quia excepturi. Adipisci eius deserunt aut ipsam aperiam. Eveniet aut qui fugiat dolorem.", "https://picsum.photos/640/480/?image=1008", new DateOnly(2024, 2, 19), "Generic Plastic Table" },
                    { 10, 9726.3700000000008, 2, new DateOnly(2025, 5, 31), "Perferendis omnis ut laboriosam dolor assumenda corporis rem expedita dolores. Saepe deserunt sed vero nemo. Sint eveniet eaque excepturi ab ea quae enim eos iusto.", "https://picsum.photos/640/480/?image=859", new DateOnly(2024, 9, 13), "Incredible Rubber Mouse" }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "CampaignId", "InfluencerId", "SignedDate" },
                values: new object[,]
                {
                    { 1, 10, 11, new DateOnly(2024, 1, 18) },
                    { 2, 8, 19, new DateOnly(2024, 3, 23) },
                    { 3, 10, 16, new DateOnly(2023, 9, 19) },
                    { 4, 5, 14, new DateOnly(2024, 3, 13) },
                    { 5, 10, 18, new DateOnly(2023, 10, 23) },
                    { 6, 4, 11, new DateOnly(2023, 12, 17) },
                    { 7, 3, 18, new DateOnly(2023, 9, 18) },
                    { 8, 5, 18, new DateOnly(2024, 8, 13) },
                    { 9, 4, 11, new DateOnly(2023, 10, 30) },
                    { 10, 4, 16, new DateOnly(2024, 6, 27) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
