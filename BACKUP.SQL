CREATE TABLE persion.persioninfo (
  PersionCode varchar(36) NOT NULL,
  PersionName varchar(36) NOT NULL,
  Brithday varchar(255) DEFAULT NULL,
  Gender char(6) DEFAULT NULL,
  address varchar(255) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (PersionCode)
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 2048,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;
INSERT INTO persioninfo
VALUES ('PS2', 'Nguyen Viet Thang','22/3/2002','1','Ha Noi');
INSERT INTO persioninfo
VALUES ('PS3', 'Nguyen Van Hoang','12/2/2000','2','Hai Duong');
INSERT INTO persioninfo
VALUES ('PS4', 'Dao Viet Anh','1/12/2012','1','Ha Nam');
INSERT INTO persioninfo
VALUES ('PS5', 'Huu Duy Quang','2/7/2009','2','Bac Ninh');
INSERT INTO persioninfo
VALUES ('PS6', 'Dinh Van Dung','1/5/2022','2','Ha Tay');
INSERT INTO persioninfo
VALUES ('PS7', 'Ha Van Viet','22/12/2002','1','Dong Anh' );
INSERT INTO persioninfo
VALUES ('PS8', 'Nguyen Thi Hoa','18/12/1992','1','Hue');


DELETE FROM persioninfo WHERE PersionCode ='';