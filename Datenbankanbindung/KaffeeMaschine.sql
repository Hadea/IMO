


create table recipies (
ID tinyint unsigned not null primary key,
Name varchar(20) not null unique,
CoffeeAmount tinyint not null default 0,
CoffeeMultiplier decimal(3,2) not null default 1,
WaterAmount tinyint not null default 0,
WaterMultiplier decimal(3,2) not null default 1,
TeaAmount tinyint not null default 0,
TeaMultiplier decimal(3,2) not null default 1,

constraint ccRecipies_CoffeeMultiplier check ( CoffeeMultiplier between 0.5 and 4 ),
constraint ccRecipies_WaterMultiplier check ( WaterMultiplier between 0.5 and 4 ),
constraint ccRecipies_TeaMultiplier check ( TeaMultiplier between 0.5 and 4 )
);

create table SavedSettings (
    coffeeContainer tinyint unsigned not null,
    waterContainer tinyint unsigned not null,
    teaContainer tinyint unsigned not null,
    lastProduct tinyint unsigned null,
    constraint ccSavedSettings_waterContainerMax check ( waterContainer < 201  ),
    constraint fkSavedSettings_Recipies foreign key (lastProduct) references Recipies (ID)
);

insert into SavedSettings values
(200,200,200,null);

insert into recipies (Name, CoffeeAmount, WaterAmount, TeaAmount, ID) values
('Kaffee', 5,10,0,1),
('Tee',0,10,3,2),
('Wasser',0,10,0,3)