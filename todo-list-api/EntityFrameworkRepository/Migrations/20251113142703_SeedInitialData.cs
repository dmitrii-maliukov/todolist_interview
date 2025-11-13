using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoList.EntityFrameworkRepository.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "CreatedAt", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("97108c8d-542c-41df-9d53-90e26f202ee2"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), null, "First grader books" },
                    { new Guid("caf9f07b-75b5-4425-8b39-a3880839fa95"), new DateTime(2025, 11, 11, 14, 27, 2, 441, DateTimeKind.Utc).AddTicks(2372), "Got it from Hagrid", "Hogwart's first grader shopping list" }
                });

            migrationBuilder.InsertData(
                table: "TodoListItems",
                columns: new[] { "Id", "CreatedAt", "Description", "Title", "TodoListId" },
                values: new object[,]
                {
                    { new Guid("15e7015e-c906-4589-ac9d-1aed41609de9"), new DateTime(2025, 11, 11, 14, 27, 2, 441, DateTimeKind.Utc).AddTicks(2372), "pewter, standard size 2", "1 Cauldron", new Guid("caf9f07b-75b5-4425-8b39-a3880839fa95") },
                    { new Guid("4527444b-24ba-4513-a1c9-0840d0a1a104"), new DateTime(2025, 11, 11, 14, 27, 2, 441, DateTimeKind.Utc).AddTicks(2372), "", "1 Wand", new Guid("caf9f07b-75b5-4425-8b39-a3880839fa95") },
                    { new Guid("4ef78f57-a4c5-49e9-8bba-e863913d9cb5"), new DateTime(2025, 11, 11, 14, 27, 2, 441, DateTimeKind.Utc).AddTicks(2372), "", "1 set of brass scales", new Guid("caf9f07b-75b5-4425-8b39-a3880839fa95") },
                    { new Guid("5935aece-d1ee-454d-8e8e-7cc9654c42cd"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), "by Arsenius Jigger", "Magical Drafts and Potions", new Guid("97108c8d-542c-41df-9d53-90e26f202ee2") },
                    { new Guid("abeaa704-a0de-4b62-855e-dc1e59d88713"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), "by Emeric Switch", "A Beginner's Guide to Transfiguration", new Guid("97108c8d-542c-41df-9d53-90e26f202ee2") },
                    { new Guid("ad826e1a-e00a-4b11-a6e0-5ab4123d3ad0"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), "by Bathilda Bagshot", "A History of Magic", new Guid("97108c8d-542c-41df-9d53-90e26f202ee2") },
                    { new Guid("adf888fe-047c-4723-87eb-8a71edf42b07"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), "by Quentin Trimble", "The Dark Forces: A Guide to Self-Protection", new Guid("97108c8d-542c-41df-9d53-90e26f202ee2") },
                    { new Guid("bfc93b39-37a4-4bcd-b5ad-52d026456f19"), new DateTime(2025, 11, 11, 14, 27, 2, 441, DateTimeKind.Utc).AddTicks(2372), "An Owl or a Cat or a Toad", "Students may also bring a pet", new Guid("caf9f07b-75b5-4425-8b39-a3880839fa95") },
                    { new Guid("c8d87d00-47b3-46bc-a22a-1730d701dac5"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), "Grade 1 by Miranda Goshawk", "The Standard Book of Spells", new Guid("97108c8d-542c-41df-9d53-90e26f202ee2") },
                    { new Guid("c97381a8-1611-42fb-980f-30589ef61fb4"), new DateTime(2025, 11, 11, 14, 27, 2, 441, DateTimeKind.Utc).AddTicks(2372), "", "1 telescope", new Guid("caf9f07b-75b5-4425-8b39-a3880839fa95") },
                    { new Guid("d27f2c86-c97b-4419-be59-c63bdeb3bff3"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), "by Adalbert Waffling", "Magical Theory", new Guid("97108c8d-542c-41df-9d53-90e26f202ee2") },
                    { new Guid("e5b38cba-4b9f-4bbc-8709-dd45eee7cd2b"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), "by Phyllida Spore", "One Thousand Magical Herbs and Fungi", new Guid("97108c8d-542c-41df-9d53-90e26f202ee2") },
                    { new Guid("f9b1b7cf-798a-42e8-ad0b-9099214cc1fe"), new DateTime(2025, 11, 11, 14, 32, 2, 444, DateTimeKind.Utc).AddTicks(7159), "by Newt Scamander", "Fantastic Beasts and Where to Find Them", new Guid("97108c8d-542c-41df-9d53-90e26f202ee2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("15e7015e-c906-4589-ac9d-1aed41609de9"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("4527444b-24ba-4513-a1c9-0840d0a1a104"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("4ef78f57-a4c5-49e9-8bba-e863913d9cb5"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("5935aece-d1ee-454d-8e8e-7cc9654c42cd"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("abeaa704-a0de-4b62-855e-dc1e59d88713"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("ad826e1a-e00a-4b11-a6e0-5ab4123d3ad0"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("adf888fe-047c-4723-87eb-8a71edf42b07"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("bfc93b39-37a4-4bcd-b5ad-52d026456f19"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("c8d87d00-47b3-46bc-a22a-1730d701dac5"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("c97381a8-1611-42fb-980f-30589ef61fb4"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("d27f2c86-c97b-4419-be59-c63bdeb3bff3"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("e5b38cba-4b9f-4bbc-8709-dd45eee7cd2b"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("f9b1b7cf-798a-42e8-ad0b-9099214cc1fe"));

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: new Guid("97108c8d-542c-41df-9d53-90e26f202ee2"));

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: new Guid("caf9f07b-75b5-4425-8b39-a3880839fa95"));
        }
    }
}
