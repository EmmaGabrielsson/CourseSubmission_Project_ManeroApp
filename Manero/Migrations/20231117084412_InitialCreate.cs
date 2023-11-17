using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf08796a-4591-49f3-8dca-0960eedd1fbc", "AQAAAAIAAYagAAAAEJegvb8nwRfv9+IRA6Q9brEX63Rwd4kB5LEhSQMLbLpo45ClKmSxrt0jcCu8qJk4EQ==", "4ec65812-9355-4e75-a27d-f8842bd87327" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f75883b-125b-49b9-a3f1-931b83d05199",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4347dc99-0a54-4b71-9746-c19b06f05683", "AQAAAAIAAYagAAAAEJegvb8nwRfv9+IRA6Q9brEX63Rwd4kB5LEhSQMLbLpo45ClKmSxrt0jcCu8qJk4EQ==", "df8e8647-e76e-4dc8-9a0a-5b2a36e8153a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b21a87a-aa26-4c90-9a2d-4c81205a0721",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8ffdddf-5f7e-4e18-9f94-e7c4ad2d05be", "AQAAAAIAAYagAAAAEJegvb8nwRfv9+IRA6Q9brEX63Rwd4kB5LEhSQMLbLpo45ClKmSxrt0jcCu8qJk4EQ==", "30b50286-3bbd-48af-b4d1-ab98e1e2c3d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c0953b8-2111-4bb5-b60d-41cc6cc0bf69", "AQAAAAIAAYagAAAAEJegvb8nwRfv9+IRA6Q9brEX63Rwd4kB5LEhSQMLbLpo45ClKmSxrt0jcCu8qJk4EQ==", "2e3e59dd-decb-4df8-b94b-dfb5c1d7eb4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a965429c-a368-4abc-8f62-a9022a691a2d", "AQAAAAIAAYagAAAAEJegvb8nwRfv9+IRA6Q9brEX63Rwd4kB5LEhSQMLbLpo45ClKmSxrt0jcCu8qJk4EQ==", "06e8e1c6-3c37-4f75-9e7b-ae6e21a86dff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdd0fa00-4cd2-4909-b1ae-9fcc527d528d", "AQAAAAIAAYagAAAAEJegvb8nwRfv9+IRA6Q9brEX63Rwd4kB5LEhSQMLbLpo45ClKmSxrt0jcCu8qJk4EQ==", "495b8b7d-8da0-432f-a8ca-49d0648a1676" });

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("0ad7551d-9a60-43ce-b475-7a19e0e1d18a"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("0c2bd56c-2ec9-4a27-8b25-c51ca5e6f6db"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("0ce7d3f6-0c8e-46a2-8e70-7a9a86e2a00d"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("0e9eddba-88db-480f-8a12-2e8ebaf9bde8"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("15d775e1-6ed2-487a-81d4-d7ca9e6f4e9a"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("18a2a186-631f-475a-8d83-190c16f9c525"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("1cb6f65d-1f22-4c14-9c6b-3fc7a4f9b8ed"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("1edf8dc8-07ea-41e4-8c1f-8a1f7ff0e0d7"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("218e882b-ae56-4a9a-8fc0-1f5da0f7f2c5"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("2b17df60-c61d-4fb3-9f2b-27132d57d2d3"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("34f7c62e-d7d9-4bd3-98ad-8c6c3b16839f"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("3b4b3c38-5eb6-4e36-8a23-1bba8ed82f3d"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("3bce2f0d-1d42-4b11-af2a-8d59ac6b87f7"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("48c3f19f-2eeb-4e15-8f75-6d1e2dd408c9"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("4a9c16d5-3e61-4a07-bffe-c24f21a2aabb"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("4f8c9c3c-ae0d-44e9-82c9-899cead3e8c8"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("631a44dd-7f0e-44e9-9fa6-08e2c4ee8ecb"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("6d0a69eb-51a7-4c21-bba6-780de40bc3ca"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("6e6a4be1-0b08-4c18-ae90-3ec1d2cf30cb"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("6f9a4c8f-6cc3-49db-9a79-c6fe3a29fc3d"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("7a9a4502-3f42-4c0e-95e3-774fe9d1a96c"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("7b9d3e7c-c4ed-44d2-8dcd-d5a0c3b4f7ed"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("7cc7cf7a-e8a7-46ef-9e17-c4ac3b74a9bc"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("7d8c89db-4ea3-4e3f-8a47-3e2ea1b6e4bc"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("a15e3c6a-691d-443e-82b6-cffce1dc3dc3"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("a7ef79fb-4a19-46f3-8300-8b17a9715b0d"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("b20cd82f-8f11-4a13-b0fc-d71dd9f4b9eb"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("b2e4f8ec-1e88-47b3-9f43-850b9ad37e1f"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("c2b1bf4a-8cc4-4a59-9361-710c4eef7b45"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("c7b8c9ae-2a8f-4c11-9f5d-8f95e9728ff1"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("ccedf9cd-4fb4-4a07-98f6-853d165a85cd"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("d3dd10e3-8f3d-49ea-92ec-8f7cd2b5b0cd"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("d78a5d59-3d22-4d24-9a72-9a0c5d64e962"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("d7d8b2ef-e7dd-45c5-9a77-9d5695d2b6f1"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("e499542e-83e5-4a11-b1c3-184c3be4a8a4"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("e4f2f0ff-85a6-40c9-8c14-962d2a28ff75"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("e8cf3f5c-1c7d-45ed-9ea6-cac3c4db07e1"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("e99881b5-90e6-4a15-91ec-2c1c3a685c0e"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("f3ecfaec-8eb5-4e60-af1b-7f2a4d3d08ca"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("f4242cc7-7dd3-4b7d-91f3-85d6cfe24222"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("f7e0ecf2-0da4-49a2-980a-9b8a703b34cb"),
                column: "Created",
                value: new DateTime(2023, 11, 17, 9, 44, 12, 428, DateTimeKind.Local).AddTicks(7462));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba50391-1bae-4304-92e1-183b69c16624", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "81fa12e1-b9f1-4fa2-819d-d478a5a01eb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f75883b-125b-49b9-a3f1-931b83d05199",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65de4279-0f13-4d45-8116-395bcb628eee", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "06c058ab-9366-4be7-bcc0-dcf7b0a94e79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b21a87a-aa26-4c90-9a2d-4c81205a0721",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46b34db9-151f-43c3-af0d-2a63a90b57ab", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "09b7f820-6d5f-4005-8b70-b23962dadc5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1be50a10-03b0-42f9-a51d-3fc09245771f", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "e90372cf-6ede-4296-847a-dbc55fd8eb6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e48e8961-101a-4b94-8299-c1640a72af72", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "9e521546-f054-42b9-b505-bc5d8b43e744" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb8aa037-fb24-4f06-a69e-7706a48d1a95", "AQAAAAIAAYagAAAAEB9UI0BgnhUihwAha8AMt3dZKTUd34wUuazsHvL0ETiWCA94qbryesPZzmnD9h5UsA==", "8d854789-ebd1-4926-87fc-2ea0637dc6d4" });

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("0ad7551d-9a60-43ce-b475-7a19e0e1d18a"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("0c2bd56c-2ec9-4a27-8b25-c51ca5e6f6db"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("0ce7d3f6-0c8e-46a2-8e70-7a9a86e2a00d"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("0e9eddba-88db-480f-8a12-2e8ebaf9bde8"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("15d775e1-6ed2-487a-81d4-d7ca9e6f4e9a"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("18a2a186-631f-475a-8d83-190c16f9c525"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("1cb6f65d-1f22-4c14-9c6b-3fc7a4f9b8ed"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("1edf8dc8-07ea-41e4-8c1f-8a1f7ff0e0d7"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("218e882b-ae56-4a9a-8fc0-1f5da0f7f2c5"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("2b17df60-c61d-4fb3-9f2b-27132d57d2d3"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("34f7c62e-d7d9-4bd3-98ad-8c6c3b16839f"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("3b4b3c38-5eb6-4e36-8a23-1bba8ed82f3d"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("3bce2f0d-1d42-4b11-af2a-8d59ac6b87f7"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("48c3f19f-2eeb-4e15-8f75-6d1e2dd408c9"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("4a9c16d5-3e61-4a07-bffe-c24f21a2aabb"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("4f8c9c3c-ae0d-44e9-82c9-899cead3e8c8"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("631a44dd-7f0e-44e9-9fa6-08e2c4ee8ecb"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("6d0a69eb-51a7-4c21-bba6-780de40bc3ca"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("6e6a4be1-0b08-4c18-ae90-3ec1d2cf30cb"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("6f9a4c8f-6cc3-49db-9a79-c6fe3a29fc3d"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("7a9a4502-3f42-4c0e-95e3-774fe9d1a96c"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("7b9d3e7c-c4ed-44d2-8dcd-d5a0c3b4f7ed"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("7cc7cf7a-e8a7-46ef-9e17-c4ac3b74a9bc"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("7d8c89db-4ea3-4e3f-8a47-3e2ea1b6e4bc"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("a15e3c6a-691d-443e-82b6-cffce1dc3dc3"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("a7ef79fb-4a19-46f3-8300-8b17a9715b0d"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("b20cd82f-8f11-4a13-b0fc-d71dd9f4b9eb"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("b2e4f8ec-1e88-47b3-9f43-850b9ad37e1f"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("c2b1bf4a-8cc4-4a59-9361-710c4eef7b45"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("c7b8c9ae-2a8f-4c11-9f5d-8f95e9728ff1"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("ccedf9cd-4fb4-4a07-98f6-853d165a85cd"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("d3dd10e3-8f3d-49ea-92ec-8f7cd2b5b0cd"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("d78a5d59-3d22-4d24-9a72-9a0c5d64e962"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("d7d8b2ef-e7dd-45c5-9a77-9d5695d2b6f1"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("e499542e-83e5-4a11-b1c3-184c3be4a8a4"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("e4f2f0ff-85a6-40c9-8c14-962d2a28ff75"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("e8cf3f5c-1c7d-45ed-9ea6-cac3c4db07e1"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("e99881b5-90e6-4a15-91ec-2c1c3a685c0e"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("f3ecfaec-8eb5-4e60-af1b-7f2a4d3d08ca"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("f4242cc7-7dd3-4b7d-91f3-85d6cfe24222"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("f7e0ecf2-0da4-49a2-980a-9b8a703b34cb"),
                column: "Created",
                value: new DateTime(2023, 11, 13, 13, 17, 36, 67, DateTimeKind.Local).AddTicks(7812));
        }
    }
}
