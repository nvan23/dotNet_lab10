Create database QLSV;
use QLSV;

drop table SinhVien

create table SinhVienOfVan(
	MaSV nvarchar(5) not null primary key,
	TenSV nvarchar(255) not null,
	Phai nvarchar(5) not null,
	Lop nvarchar(10) not null,
);

Create Table SinhVien (
	MaSV nvarchar(10) not null primary key,
	TenSV nvarchar(50) not null,
	Phai bit not null,
	Lop nvarchar(10) not null,
);


insert into SinhVien values('12345',N'Vân Cute 1',1,'DI16V7F1');
insert into SinhVien values('12346',N'Vân Cute 2',1,'DI16V7F2');
insert into SinhVien values('12347',N'Vân Cute 3',0,'DI16V7F2');
insert into SinhVien values('12348',N'Vân Cute 4',1,'DI16V7F2');
insert into SinhVien values('12349',N'Vân Cute 5',0,'DI16V7F2');
insert into SinhVien values('12341',N'Vân Cute 6',1,'DI16V7F1');
insert into SinhVien values('12342',N'Vân Cute 7',1,'DI16V7F2');
insert into SinhVien values('12343',N'Vân Cute 8',0,'DI16V7F2');
insert into SinhVien values('12344',N'Vân Cute 9',1,'DI16V7F1');
insert into SinhVien values('12355',N'Vân Cute 10',1,'DI16V7F1');
insert into SinhVien values('12356',N'Vân Cute 11',1,'DI16V7F1');
insert into SinhVien values('12357',N'Vân Cute 12',0,'DI16V7F2');
insert into SinhVien values('12358',N'Vân Cute 13',1,'DI16V7F1');


select * from SinhVien;