create table Contorizare
(
	id int identity primary key,
	tip varchar(25),
	tabel varchar(25),
	dataExec datetime
)
GO
insert into Depozite values('Adam','Primul depozit',35,'Noice');
insert into Clienti values('WEB','nou',41404571);
GO
create function validareDepozite
(@NumeDepozite varchar(100), @DescriereDepozite varchar(100), @Capacitate int, @LocatieDepozite varchar(100))
returns int
as
begin
   declare @eroare int
   set @eroare = 1
   if (@NumeDepozite Like '')
       set @eroare=0
   if (@DescriereDepozite Like '')
       set @eroare=0
   if (@Capacitate <0) 
       set @eroare=0
   if (@LocatieDepozite Like '')
       set @eroare=0
   return @eroare
end

GO
create function validareClienti
(@NumeClienti varchar(100),@FidelitateClienti varchar(100), @Cardu int)
returns int
as
begin
    declare @eroare int
	set @eroare=1
    if (@NumeClienti Like '')
	 set @eroare=0
    if (@FidelitateClienti Like '')
	 set @eroare=0
    if (@Cardu <0)
	 set @eroare=0
	return @eroare
end
GO
create or alter procedure AdaugaDepoziteClienti 
(@NumeDepozite varchar(100), @DescriereDepozite varchar(100), @Capacitate int, @LocatieDepozite varchar(100),@NumeClienti varchar(100),@FidelitateClienti varchar(100), @Cardu int, @DescriereAsignare varchar(50))
as
DECLARE @cod_2i int;
SET @cod_2i=0;
SELECT @cod_2i =MAX(cod_2) from Depozite;

DECLARE @cod_4i int;
SET @cod_4i=0;
SELECT @cod_4i = MAX(cod_4) from Clienti;
begin 
   begin tran
   begin try
      declare @eroare varchar(300)
	     set @eroare=dbo.validareClienti(@NumeClienti,@FidelitateClienti, @Cardu)
		 if (@eroare != 1)
		begin
			raiserror(@eroare,14,1)
		end
		insert into Clienti values (@NumeClienti,@FidelitateClienti, @Cardu)
		insert into Contorizare(tip,tabel,dataExec) values ('adaugare','Clienti',CURRENT_TIMESTAMP)
		set @eroare = dbo.validareDepozite(@NumeDepozite, @DescriereDepozite, @Capacitate, @LocatieDepozite)
		if (@eroare != 1)
		begin
			raiserror(@eroare,14,1)
		end
		insert into Depozite values (@NumeDepozite, @DescriereDepozite, @Capacitate, @LocatieDepozite)
		insert into Contorizare(tip,tabel,dataExec) values ('adaugare','Depozite',CURRENT_TIMESTAMP)
		print(@cod_2i)
		print(@cod_4i)
		insert into Clienti_int values (@cod_2i,@cod_4i)
		insert into Contorizare(tip,tabel,dataExec) values ('adaugare','Clienti_int',CURRENT_TIMESTAMP)
		commit tran
		select 'commited'
	end try
	begin catch
		SELECT ERROR_MESSAGE() AS ErrorMessage;
		rollback tran
		select 'rollbacked'
		insert into Contorizare(tip, tabel, dataExec) values ('rollback', 'Clienti', CURRENT_TIMESTAMP)
	end catch
end
GO
Exec AdaugaDepoziteClienti 'Donisan','Depou mare',2000,'Nojorid','Mihai','Om de baza',56791289,'Asignat'
Exec AdaugaDepoziteClienti 'Mateescu','Depou mediu',500,'Hasdeu','Naghi','Om de baza',12343214,'Asignat'
select * from Clienti
select * from Depozite
select * from Clienti_int
select * from Contorizare

GO
create or alter procedure AdaugaDepoziteClienti2 (@NumeDepozite varchar(100), @DescriereDepozite varchar(100), @Capacitate int, @LocatieDepozite varchar(100),@NumeClienti varchar(100),@FidelitateClienti varchar(100), @Cardu int, @DescriereAsignare varchar(50))
as
begin
declare @eroare int
set @eroare = 0
DECLARE @cod_2i int;
SET @cod_2i=0;
SELECT @cod_2i =MAX(cod_2) from Depozite;

DECLARE @cod_4i int;
SET @cod_4i=0;
SELECT @cod_4i = MAX(cod_4) from Clienti;
begin tran
	begin try
		declare @mesaj_eroare varchar(250)
		set @eroare=dbo.validareClienti(@NumeClienti,@FidelitateClienti, @Cardu)
		 if (@eroare != 1)
		begin
			raiserror(@eroare,14,1)
		end
		insert into Clienti values (@NumeClienti,@FidelitateClienti, @Cardu)
		insert into Contorizare(tip,tabel,dataExec) values ('adaugare','Clienti',CURRENT_TIMESTAMP)
		commit tran
		select 'commited pentru Clienti.'
	end try
	begin catch
		SELECT ERROR_MESSAGE() AS ErrorMessage;
		rollback tran
		select 'rollbacked pentru Proiecte.'
		insert into Contorizare(tip, tabel, dataExec) values ('rollback', 'Clienti', CURRENT_TIMESTAMP)
		set @eroare = 1
	end catch

	if (@eroare != 1)
		return
	begin tran
	begin try
	set @eroare = dbo.validareDepozite(@NumeDepozite, @DescriereDepozite, @Capacitate, @LocatieDepozite)
		if (@eroare != 1)
		begin
			raiserror(@eroare,14,1)
		end
		insert into Depozite values (@NumeDepozite, @DescriereDepozite, @Capacitate, @LocatieDepozite)
		insert into Contorizare(tip,tabel,dataExec) values ('adaugare','Depozite',CURRENT_TIMESTAMP)
		commit tran
		select 'commited pentru Depozite.'
	end try
	begin catch
		 SELECT ERROR_MESSAGE() AS ErrorMessage;
		rollback tran
		select 'rollbacked pentru Angajati.'
		insert into Contorizare(tip, tabel, dataExec) values ('rollback', 'Depozite', CURRENT_TIMESTAMP)
		set @eroare = 1
	end catch
	begin tran
	begin try
     insert into Clienti_int values (@cod_2i,@cod_4i)
		insert into Contorizare(tip,tabel,dataExec) values ('adaugare','Clienti_int',CURRENT_TIMESTAMP)
		commit tran
		select 'commited'
	end try
	begin catch
		SELECT ERROR_MESSAGE() AS ErrorMessage;
		rollback tran
		select 'rollbacked pentru Asignare.'
		insert into Contorizare(tip, tabel, dataExec) values ('rollback', 'Clienti_int', CURRENT_TIMESTAMP)
		set @eroare = 1
	end catch
end
GO
Exec AdaugaDepoziteClienti2 'Holcim','Depou mare',3000,'Osorhei','Mohnici','De o vreme',12341234,'Asignat'
Exec AdaugaDepoziteClienti2 'Promenada','',275,'Cluj','Mihailescu','Om de baza',43214321,'Asignat'
select * from Clienti
select * from Depozite
select * from Clienti_int
select * from Contorizare