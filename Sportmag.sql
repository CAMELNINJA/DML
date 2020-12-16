Create DATABASE Sportmag;
create table person
(
    id serial not null constraint person_pkey primary key ,
    first_name varchar(30),
    last_name  varchar(30)
);
create table authentication
(
pers_id serial not null constraint person_fkey references person,
login varchar(30),
pasword varchar(70)
);
create table kind_of_sport
(
id serial not null constraint kind_of_sport_pkey primary key ,
name varchar(30)
);
create table sale
(
    id serial not null constraint sale_pkey primary key ,
    name varchar(30),
    prise integer,
    count integer,
    kind_of_spot varchar(30),
    kof_id serial not null constraint kind_of_sport_fkey references kind_of_sport
);
create table basket
(
    preson_id serial not null constraint person_fkey references person,
    sale_id serial not null constraint sale_fkey references sale,
    count integer not null
);
INSERT INTO kind_of_sport(id,name)VALUES (0,'Все товары'),(1,'Хоккей'),(2,'Футбол'),(3,'Бег'),(4,'Спорт питание');
Alter TABLE sale ADD COLUMN  image text;
INSERT INTO sale (id,name, prise, count, kind_of_spot,kof_id,image) values (0,'Коньки',1200,3,'Хоккей',1,'/image/похуй.jpg'),
                                                                           (1,'Грудной щиток',5000,1,'Хоккей',1,'/image/похуй.jpg'),
                                                                           (2,'Шлем',4000,1,'Хоккей',1,'/image/похуй.jpg'),
                                                                           (3,'Бутсы',3200,3,'Футбол',2,'/image/похуй.jpg'),
                                                                           (4,'Кроссовки',1000,10,'Бег',3,'/image/похуй.jpg'),
                                                                           (5,'Ботончик',230,100,'Спорт Питание' ,4,'/image/похуй.jpg'),
                                                                           (6,'Протэин',100,100,'Спорт Питание' ,4,'/image/похуй.jpg');
DELETE from person;
create table chat(
    id serial not null constraint chat_pk primary key ,
    sale_id serial not null constraint sale_fkey references sale,
    person_id serial not null constraint person_fkey references person,
    text varchar(95),
    data timestamp not null
);
Alter TABLE chat ADD COLUMN  name varchar(30);