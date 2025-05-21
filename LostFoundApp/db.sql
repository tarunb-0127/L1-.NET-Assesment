CREATE TABLE lost_items(    
    item_id INT PRIMARY KEY AUTO_INCREMENT,
    item_name varchar(20),
    item_type varchar(20),
    lost_date date,
    recovery_status varchar(20));

CREATE TABLE lost_items2(    
    item_id INT PRIMARY KEY AUTO_INCREMENT,
    item_type varchar(20),
    lost_date date,
    recovery_status varchar(20));

CREATE TABLE lost_items3(    
    item_id INT PRIMARY KEY AUTO_INCREMENT,
    item_type varchar(20),
    lost_date date,
    recovery_status varchar(20));
    item_id foreign key references mobile_phones(item_id);

CREATE TABLE mobile_phones(
    item_id INT PRIMARY KEY AUTO_INCREMENT,
    phone_number varchar(20),
    phone_brand varchar(20),
    phone_model varchar(20),
    imei_number varchar(20)
    
);

