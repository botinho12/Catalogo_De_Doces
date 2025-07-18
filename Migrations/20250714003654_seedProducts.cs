﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoDeDoces.Migrations
{
    public partial class seedProducts : Migration
    {
        private static readonly string[] columns = new[] { "Nome", "Descricao", "Preco", "ImagemUrl" };

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: columns,
                values: new object[,]
                {
                    { "Paçoquita Santa Helena c/50", "Paçoquita santa helena dp com 50 unidades todas embaladas", 3.5, "https://jadoces.com.br/wp-content/uploads/2022/08/155487-1600-auto-300x300.jpg.webp" },
                    { "Brigadeiro Tradicional Unidade", "Doce de chocolate com granulado", 3.2, "https://ogimg.infoglobo.com.br/in/24630647-52c-bd7/FT1086A/WhatsApp-Image-2020-09-09-at-11.39.36.jpeg.jpg" },
                    { "Beijinho Gourmet unidade", "Doce de coco com leite condensado e coco fresco", 4.0, "https://cdn.casaeculinaria.com/wp-content/uploads/2023/05/16103507/Beijinho-500x500.webp" },
                    { "Brigadeiro Gourmet unidade", "Doce de chocolate belga com granulado premium", 4.5, "https://www.marajoaraalimentos.com.br/2018/wp-content/uploads/2020/07/349-scaled.jpg" },
                    { "Paçoca Moreninha do Rio c/50", "Paçoca moreninha do rio pote com 50 unidades", 18.00, "https://acdn-us.mitiendanube.com/stores/002/547/070/products/1141-9cafc074873738137b16915243850729-1024-1024.png" },
                    { "Pé De Moça Manamel c/20", "Delicie-se com o Pé de Moça Manamel." +
                                          " Neste pote generoso de 1,1kg, a crocância do amendoim se encontra com a suavidade do doce de leite, " +
                                          "criando uma textura macia e um sabor irresistível.", 17.99, 
                        "https://th.bing.com/th/id/OIP.iRFTdpqteJgQp9DSrYifuQHaHU?w=218&h=215&c=7&r=0&o=7&pid=1.7&rm=3" },
                    { "Cajuzinho Baruk c/20", "Doce de Amendoim recheado com doce de leite", 35.49, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwnZBzFt9iyAlbpUqjLfrDQ-jHkm9hit5_bA&s" },
                    { "Cocada Pingada mista Baruk c/30", "Cocada Mista Baruk pote com 20 unidades", 20.00, "https://docemalu.vtexassets.com/arquivos/ids/5355538-800-auto?v=638563994702300000&width=800&height=auto&aspect=true" },
                    { "Palha Italiana Famoso c/20", "PALHA ITALIANA DISPLAY C/20 UND 600G", 18.00, "https://www.deliciasfamoso.com.br/wp-content/uploads/2024/10/Beijinho-com-Ameixa-11.png" },
                    { "Beijinho de coco c/21", "BEIJINHO DE COCO PT C/21 UND 1,01 KG", 18.00, "https://www.deliciasfamoso.com.br/wp-content/uploads/2024/10/Beijinho-com-Ameixa-12.png" },
                    { "Beijinho De Goiabada c/21", "BEIJINHO DE GOIABA PT C/50 UND 1,02 KG", 18.00, "https://www.deliciasfamoso.com.br/wp-content/uploads/2024/10/Beijinho-com-Ameixa-13.png" },
                    { "Brigadeiro Famoso c/21", "BRIGADEIRO PT C/21 UND 1,01KG", 18.00, "https://www.deliciasfamoso.com.br/wp-content/uploads/2024/10/Beijinho-com-Ameixa-14.png" },
                    
                });
        }
        protected override void Down(MigrationBuilder migrationBuilder) => migrationBuilder.Sql
            ("DELETE FROM Produtos WHERE Nome IN ('Beijinho Tradicional', 'Brigadeiro Tradicional', 'Beijinho Gourmet', 'Brigadeiro Gourmet')");
    }
}