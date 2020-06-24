create database juntoteste;

use juntoteste;

create table  user(
uid int auto_increment primary key,
ulogin  varchar(255) not null,
uname varchar(255) not null,
upassword varchar(255) not null
);