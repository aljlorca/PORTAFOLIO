---------------------------------------------------------------------
----PROCEDIMIENTOS DE ALMACENADO PARA FUNCIONAMIENTO DE LAS APIS ----
---------------------------------------------------------------------

------------------------- SP CARGO -----------------------------------------------------------
create sequence sec_cargo
  start with 1
  increment by 1
  maxvalue 99999
  minvalue 1;
  
  
  
create or replace PROCEDURE CARGO_ELIMINAR (v_id_cargo Integer, v_salida out number) is
begin 
    UPDATE cargo
    SET estado_fila = '0'
    WHERE id_cargo = v_id_cargo;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;



end CARGO_ELIMINAR;


create or replace PROCEDURE CARGO_AGREGAR 
(
    v_nombre varchar2,
    v_estado_fila char,
    v_salida out number

) is
begin 
  insert into CARGO(id_cargo, nombre_cargo,estado_fila) values(sec_cargo.nextval,v_nombre,v_estado_fila);
  commit;
  v_salida:=1;
  
  exception when others then v_salida:=0;

end CARGO_AGREGAR;


create or replace PROCEDURE CARGO_MODIFICAR (
    v_id Integer,
    v_nombre_cargo VARCHAR2,
    v_salida out number

) is
begin 
    UPDATE cargo
    SET nombre_cargo = v_nombre_cargo
    WHERE id_cargo = v_id;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end CARGO_MODIFICAR;

 

create or replace PROCEDURE CARGO_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from cargo where estado_fila = '1';
end CARGO_LISTAR;



-------------------------------------------------------------------------------------------------------------------
------------------------------------- SP usuarios -----------------------------------------------------------------
create sequence sec_usuario
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE USUARIO_ELIMINAR (v_correo varchar2, v_salida out number) is
begin 
    UPDATE usuario
    SET usuario_vigente = '0'
    WHERE correo_usuario = v_correo;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end USUARIO_ELIMINAR;


create or replace PROCEDURE USUARIO_AGREGAR 
(
    v_numero_identeificacion_usuario varchar2,
    v_nombre_usuario varchar2,
    v_direccion_usuario varchar2,
    v_telefono_usuario varchar2,
    v_correo_usuario varchar2,
    v_contrasena_usuario varchar2,
    v_usuario_vigente char,
    v_fecha_creacion_usuario Date,
    v_administrador_usuario char,
    v_id_cargo Integer,
    v_id_empresa Integer,
    v_id_ciudad Integer,
    v_salida OUT NUMBER

) is
begin 
  insert into USUARIO(id_usuario,NUMERO_IDENTIFICACION_USUARIO,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,usuario_vigente,fecha_creacion_usuario,administrador_usuario,id_cargo,id_empresa,id_ciudad) 
  values(sec_usuario.nextval,v_numero_identeificacion_usuario,v_nombre_usuario,v_direccion_usuario,v_telefono_usuario,v_correo_usuario,v_contrasena_usuario,v_usuario_vigente,v_fecha_creacion_usuario,v_administrador_usuario,v_id_cargo,v_id_empresa,v_id_ciudad);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end USUARIO_AGREGAR;


create or replace PROCEDURE USUARIO_MODIFICAR (
    v_numero_identeificacion_usuario varchar2,
    v_nombre_usuario varchar2,
    v_direccion_usuario varchar2,
    v_telefono_usuario varchar2,
    v_correo_usuario varchar2,
    v_contrasena_usuario varchar2,
    v_administrador_usuario char,
    v_id_cargo Integer,
    v_id_empresa Integer,
    v_id_ciudad Integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE usuario
    SET nombre_usuario = v_nombre_usuario,
    direccion_usuario = v_direccion_usuario,
    telefono_usuario = v_telefono_usuario,
    correo_usuario = v_correo_usuario,
    contrasena_usuario = v_contrasena_usuario,
    administrador_usuario = v_administrador_usuario,
    id_cargo = v_id_cargo,
    id_empresa = v_id_empresa,
    id_ciudad = v_id_ciudad
    WHERE NUMERO_IDENTIFICACION_USUARIO = v_numero_identeificacion_usuario;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end USUARIO_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE USUARIO_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from usuario;
end USUARIO_LISTAR;

------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP PRODUCTO --------------------------------------------------------------------------

create sequence sec_producto
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE PRODUCTO_ELIMINAR (v_id_producto Integer) is
begin 
    UPDATE PRODUCTO
    SET estado_fila = '0'
    WHERE id_producto = v_id_producto;
    commit;

end PRODUCTO_ELIMINAR;


create or replace PROCEDURE                   "PRODUCTO_AGREGAR" 
(
    v_nombre_producto varchar2, 
    v_cantidad_producto integer,
    v_imagen_producto varchar2,
    v_id_empresa integer,
    v_id_calidad integer,
    v_estado_fila char,
    v_salida OUT NUMBER
) 
is
begin 
  insert into PRODUCTO(id_producto,nombre_producto,cantidad_producto,imagen_producto,id_empresa,id_calidad,estado_fila) 
  values(sec_producto.nextval,v_nombre_producto,v_cantidad_producto,v_imagen_producto,v_id_empresa,v_id_calidad,v_estado_fila);
  commit;
  v_salida:=1;
  exception when others then v_salida:=0;
end PRODUCTO_AGREGAR;


 create or replace PROCEDURE PRODUCTO_MODIFICAR (
    v_id_producto integer,
    v_nombre_producto varchar2, 
    v_cantidad_producto integer,
    v_imagen_producto varchar2,
    v_id_empresa integer,
    v_id_calidad integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE producto
    SET nombre_producto = v_nombre_producto,
    cantidad_producto = v_cantidad_producto,
    imagen_producto = v_imagen_producto,
    id_empresa = v_id_empresa,
    id_calidad = v_id_calidad
    WHERE id_producto = v_id_producto;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end PRODUCTO_MODIFICAR;

 CREATE OR REPLACE EDITIONABLE PROCEDURE PRODUCTO_LISTAR (cur_listar out SYS_REFCURSOR) 
is

begin
    open cur_listar for select * from PRODUCTO;
end PRODUCTO_LISTAR;

------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP LOGIN -----------------------------------------------------------------------------
create or replace PROCEDURE                   "LOGIN" 
(
    v_correo varchar2,
    v_contrasena varchar2,
    cur out SYS_REFCURSOR
)
is
begin
    open cur for select u.nombre_usuario,c.nombre_cargo,u.correo_usuario,u.fecha_sesion_usuario from usuario u, cargo c where u.id_cargo = c.id_cargo and u.correo_usuario = v_correo and u.contrasena_usuario = v_contrasena and u.usuario_vigente = '1';
    update usuario 
    set fecha_sesion_usuario = sysdate
    where correo_usuario=v_correo;
end LOGIN;


------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP empresa -----------------------------------------------------------------------------


create sequence sec_empresa
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE EMPRESA_ELIMINAR (v_id_empresa integer, v_salida out number) is
begin 
    UPDATE empresa
    SET estado_fila = '0'
    WHERE v_id_empresa = id_empresa;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end EMPRESA_ELIMINAR;


create or replace PROCEDURE EMPRESA_AGREGAR 
(
    v_rut_empresa varchar2,
    v_duns_empresa varchar2,
    v_razon_social_empresa varchar2,
    v_direccion_empresa varchar2,
    v_giro_empresa varchar2,
    v_id_tipo_empresa integer,
    v_id_ciudad integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into EMPRESA(id_empresa,rut_empresa,duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad,estado_fila) 
  values(sec_empresa.nextval,v_rut_empresa,v_duns_empresa,v_razon_social_empresa,v_direccion_empresa,v_giro_empresa,v_id_tipo_empresa,v_id_ciudad,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end EMPRESA_AGREGAR;


create or replace PROCEDURE EMPRESA_MODIFICAR (
    v_id_empresa integer,
    v_rut_empresa varchar2,
    v_duns_empresa varchar2,
    v_razon_social_empresa varchar2,
    v_direccion_empresa varchar2,
    v_giro_empresa varchar2,
    v_id_tipo_empresa integer,
    v_id_ciudad integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE empresa
    SET rut_empresa = v_rut_empresa,
    duns_empresa = v_duns_empresa,
    razon_social_empresa = v_razon_social_empresa,
    direccion_empresa = v_direccion_empresa,
    giro_empresa = v_giro_empresa,
    id_tipo_empresa = v_id_tipo_empresa,
    id_ciudad = v_id_ciudad
    WHERE id_empresa = v_id_empresa;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end EMPRESA_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE EMPRESA_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from empresa;
end EMPRESA_LISTAR;


------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP pedido -----------------------------------------------------------------------------


create sequence sec_pedido
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE PEDIDO_ELIMINAR (v_id_pedido integer, v_salida out number) is
begin 
    UPDATE pedido
    SET estado_fila = '0'
    WHERE v_id_pedido = id_pedido;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end PEDIDO_ELIMINAR;


create or replace PROCEDURE PEDIDO_AGREGAR 
(
    v_fecha_pedido date,
    v_id_venta_externa integer,
    v_id_producto integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into pedido(id_pedido,fecha_pedido,id_venta_externa,id_producto,estado_fila) 
  values(sec_pedido.nextval,v_fecha_pedido,v_id_venta_externa,v_id_producto,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end PEDIDO_AGREGAR;


create or replace PROCEDURE PEDIDO_MODIFICAR (
    v_id_pedido integer,
    v_fecha_pedido date,
    v_id_venta_externa integer,
    v_id_producto integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE pedido
    SET fecha_pedido = v_fecha_pedido,
    id_venta_externa = v_id_venta_externa,
    id_producto = v_id_producto
    WHERE id_pedido = v_id_pedido;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end PEDIDO_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE PEDIDO_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from pedido;
end PEDIDO_LISTAR;
------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP postulacion -----------------------------------------------------------------------------

create sequence sec_postulacion
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE POSTULACION_ELIMINAR (v_id_postulacion integer, v_salida out number) is
begin 
    UPDATE postulacion
    SET estado_fila = '0'
    WHERE v_id_postulacion = id_postulacion;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end POSTULACION_ELIMINAR;


create or replace PROCEDURE POSTULACION_AGREGAR 
(
    v_descripcion varchar2,
    v_estado varchar2,
    v_id_venta_externa integer,
    v_empresa integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into postulacion(id_postulacion,descripcion,estado,id_venta_externa,id_empresa,estado_fila) 
  values(sec_postulacion.nextval,v_descripcion,v_estado,v_id_venta_externa,v_empresa,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end POSTULACION_AGREGAR;


create or replace PROCEDURE POSTULACION_MODIFICAR 
(
    v_id_postulacion integer,
    v_descripcion varchar2,
    v_estado varchar2,
    v_id_venta_externa integer,
    v_empresa integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE postulacion
    SET descripcion = v_descripcion,
    estado = v_estado,
    id_venta_externa = v_id_venta_externa,
    id_empresa = v_empresa
    WHERE id_postulacion = v_id_postulacion;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end POSTULACION_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE POSTULACION_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from postulacion;
end POSTULACION_LISTAR;
------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP reporte -----------------------------------------------------------------------------

create sequence sec_reporte
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE REPORTE_ELIMINAR (v_id_reporte integer, v_salida out number) is
begin 
    UPDATE reporte
    SET estado_fila = '0'
    WHERE v_id_reporte = id_reporte;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end REPORTE_ELIMINAR;


create or replace PROCEDURE REPORTE_AGREGAR 
(
    v_descripcion_reporte varchar2,
    v_productos_entregados_reporte varchar2,
    v_productos_perdidos_reporte varchar2,
    v_productos_restantes_reporte varchar2,
    v_id_venta_externa integer,
    v_id_empresa integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into reporte(id_reporte,descripcion_reporte,productos_entregados_reporte,productos_perdidos_reporte,productos_restantes_reporte,id_venta_externa,id_empresa,estado_fila) 
  values(sec_reporte.nextval,v_descripcion_reporte,v_productos_entregados_reporte,v_productos_perdidos_reporte,v_productos_restantes_reporte,v_id_venta_externa,v_id_empresa,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end REPORTE_AGREGAR;


create or replace PROCEDURE REPORTE_MODIFICAR 
(
    v_id_reporte integer,
    v_descripcion_reporte varchar2,
    v_productos_entregados_reporte varchar2,
    v_productos_perdidos_reporte varchar2,
    v_productos_restantes_reporte varchar2,
    v_id_venta_externa integer,
    v_id_empresa integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE reporte
    SET descripcion_reporte = v_descripcion_reporte,
    productos_entregados_reporte = v_productos_entregados_reporte,
    productos_perdidos_reporte = v_productos_perdidos_reporte,
    productos_restantes_reporte = v_productos_restantes_reporte,
    id_venta_externa = v_id_venta_externa,
    id_empresa = v_id_empresa
    WHERE id_reporte = v_id_reporte;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end REPORTE_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE REPORTE_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from reporte;
end REPORTE_LISTAR;

------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP tipo empresa -----------------------------------------------------------------------------


create sequence sec_tipo_empresa
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE TIPO_EMPRESA_ELIMINAR (v_id_tipo_empresa integer, v_salida out number) is
begin 
    UPDATE tipo_empresa
    SET estado_fila = '0'
    WHERE id_tipo_empresa = v_id_tipo_empresa;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end TIPO_EMPRESA_ELIMINAR;


create or replace PROCEDURE TIPO_EMPRESA_AGREGAR 
(
    v_tipo_empresa varchar2,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into tipo_empresa(id_tipo_empresa,tipo_empresa,estado_fila) 
  values(sec_tipo_empresa.nextval,v_tipo_empresa,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end TIPO_EMPRESA_AGREGAR;


create or replace PROCEDURE TIPO_EMPRESA_MODIFICAR 
(
    v_id_tipo_empresa integer,
    v_tipo_empresa varchar2,
    v_salida OUT NUMBER

) is
begin 
    UPDATE tipo_empresa
    SET tipo_empresa = v_tipo_empresa
    WHERE id_tipo_empresa = v_id_tipo_empresa;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end TIPO_EMPRESA_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE TIPO_EMPRESA_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from tipo_empresa;
end TIPO_EMPRESA_LISTAR;

------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP resumen venta -----------------------------------------------------------------------------

create sequence sec_resumen_venta
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE RESUMEN_VENTA_ELIMINAR (v_id_resumen integer, v_salida out number) is
begin 
    UPDATE resumen_venta
    SET estado_fila = '0'
    WHERE id_resumen = v_id_resumen;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end RESUMEN_VENTA_ELIMINAR;


create or replace PROCEDURE RESUMEN_VENTA_AGREGAR 
(
    v_monto_neto_venta integer,
    v_descripcion_resumen varchar2,
    v_id_venta_externa integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into resumen_venta(id_resumen,monto_neto_venta,descripcion_resumen,id_venta_externa,estado_fila) 
  values(sec_resumen_venta.nextval,v_monto_neto_venta,v_descripcion_resumen,v_id_venta_externa,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end RESUMEN_VENTA_AGREGAR;


create or replace PROCEDURE RESUMEN_VENTA_MODIFICAR 
(
    v_id_resumen integer,
    v_monto_neto_venta integer,
    v_descripcion_resumen varchar2,
    v_id_venta_externa integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE resumen_venta
    SET monto_neto_venta = v_monto_neto_venta,
    descripcion_resumen = v_descripcion_resumen,
    id_venta_externa= v_id_venta_externa
    WHERE id_resumen = v_id_resumen;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end RESUMEN_VENTA_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE RESUMEN_VENTA_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from resumen_venta;
end RESUMEN_VENTA_LISTAR;


------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP saldo -----------------------------------------------------------------------------

create sequence sec_saldo
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE SALDO_ELIMINAR (v_id_saldo integer, v_salida out number) is
begin 
    UPDATE saldo
    SET estado_fila = '0'
    WHERE id_saldo = v_id_saldo;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end SALDO_ELIMINAR;


create or replace PROCEDURE SALDO_AGREGAR 
(
    v_descripcion_saldo varchar2,
    v_monto_bruto_saldo integer,
    v_iva_saldo integer,
    v_monto_neto_saldo integer,
    v_id_venta_externa integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into saldo(id_saldo,descripcion_saldo,monto_bruto_saldo,iva_saldo,monto_neto_saldo,id_venta_externa,estado_fila) 
  values(sec_saldo.nextval,v_descripcion_saldo,v_monto_bruto_saldo,v_iva_saldo,v_monto_neto_saldo,v_id_venta_externa,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end SALDO_AGREGAR;


create or replace PROCEDURE SALDO_MODIFICAR 
(
    v_id_saldo integer,
    v_descripcion_saldo varchar2,
    v_monto_bruto_saldo integer,
    v_iva_saldo integer,
    v_monto_neto_saldo integer,
    v_id_venta_externa integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE saldo
    SET descripcion_saldo = v_descripcion_saldo,
    monto_bruto_saldo = v_monto_bruto_saldo,
    iva_saldo= v_iva_saldo,
    monto_neto_saldo = v_monto_neto_saldo,
    id_venta_externa = v_id_venta_externa
    WHERE id_saldo = v_id_saldo;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end SALDO_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE SALDO_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from saldo;
end SALDO_LISTAR;

------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP venta externa -----------------------------------------------------------------------------


create sequence sec_venta_externa
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE VENTA_EXTERNA_ELIMINAR (v_id_venta_externa integer, v_salida out number) is
begin 
    UPDATE venta_externa
    SET estado_fila = '0'
    WHERE id_venta_externa = v_id_venta_externa;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end VENTA_EXTERNA_ELIMINAR;


create or replace PROCEDURE VENTA_EXTERNA_AGREGAR 
(
    v_descripcion varchar2,
    v_estado_venta varchar2,
    v_monto_bruto integer,
    v_iva integer,
    v_monto_neto integer,
    v_fecha date,
    v_id_empresa integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into venta_externa(id_venta_externa,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,fecha_venta,id_empresa,estado_fila) 
  values(sec_venta_externa.nextval,v_descripcion,v_estado_venta,v_monto_bruto,v_iva,v_monto_neto,v_fecha,v_id_empresa,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end VENTA_EXTERNA_AGREGAR;


create or replace PROCEDURE VENTA_EXTERNA_MODIFICAR 
(
    v_id_venta_externa integer,
    v_descripcion varchar2,
    v_estado_venta varchar2,
    v_monto_bruto integer,
    v_iva integer,
    v_monto_neto integer,
    v_fecha date,
    v_id_empresa integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE venta_externa
    SET descripcion_venta = v_descripcion,
    estado_venta = v_estado_venta,
    monto_bruto_venta = v_monto_bruto,
    iva = v_iva,
    monto_neto_venta = v_monto_neto,
    fecha_venta = v_fecha,
    id_empresa = v_id_empresa
    WHERE id_venta_externa = v_id_venta_externa;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end VENTA_EXTERNA_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE VENTA_EXTERNA_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from venta_externa;
end VENTA_EXTERNA_LISTAR;

------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP venta interna -----------------------------------------------------------------------------

create sequence sec_venta_interna
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE VENTA_INTERNA_ELIMINAR (v_id_venta_interna integer, v_salida out number) is
begin 
    UPDATE venta_interna
    SET estado_fila = '0'
    WHERE id_venta_interna = v_id_venta_interna;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end VENTA_INTERNA_ELIMINAR;


create or replace PROCEDURE                   "VENTA_INTERNA_AGREGAR" 
(
    v_descripcion varchar2,
    v_monto_bruto integer,
    v_iva integer,
    v_monto_neto integer,
    v_fecha date,
    v_id_saldo integer,
    v_estado_fila char,
    v_id_usuario integer,
    v_salida OUT NUMBER

) is
begin 
  insert into venta_interna(id_venta_interna,descripcion_venta_interna,monto_bruto_venta_interna,iva_venta_interna,monto_neto_venta_interna,fecha_venta_interna,id_saldo,estado_fila,id_usuario) 
  values(sec_venta_interna.nextval,v_descripcion,v_monto_bruto,v_iva,v_monto_neto,v_fecha,v_id_saldo,v_estado_fila,v_id_usuario);
  commit;
  v_salida:=1; 

  exception when others then v_salida:=0;

end VENTA_INTERNA_AGREGAR;


create or replace PROCEDURE                   "VENTA_INTERNA_MODIFICAR" 
(
    v_id_venta_interna integer,
    v_descripcion varchar2,
    v_monto_bruto integer,
    v_iva integer,
    v_monto_neto integer,
    v_fecha date,
    v_id_saldo integer,
    v_id_usuario integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE venta_interna
    SET descripcion_venta_interna = v_descripcion,
    monto_bruto_venta_interna = v_monto_bruto,
    iva_venta_interna = v_iva,
    monto_neto_venta_interna = v_monto_neto,
    fecha_venta_interna = v_fecha,
    id_saldo = v_id_saldo,
    id_usuario = v_id_usuario
    WHERE id_venta_interna = v_id_venta_interna;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end VENTA_INTERNA_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE VENTA_INTERNA_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from venta_interna where estado_fila = '1';
end VENTA_INTERNA_LISTAR;



------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP contrato -----------------------------------------------------------------------------

create sequence sec_contrato
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE CONTRATO_ELIMINAR (v_id_contrato integer, v_salida out number) is
begin 
    UPDATE contrato
    SET estado_fila = '0'
    WHERE id_contrato = v_id_contrato;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end CONTRATO_ELIMINAR;


create or replace PROCEDURE CONTRATO_AGREGAR 
(
    v_documento_contrato varchar2,
    v_fecha_contrato date,
    v_tipo_contrato varchar2,
    v_id_empresa integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into contrato(id_contrato,documento_contrato,fecha_contrato,tipo_contrato,id_empresa,estado_fila) 
  values(sec_contrato.nextval,v_documento_contrato,v_fecha_contrato,v_tipo_contrato,v_id_empresa,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end CONTRATO_AGREGAR;


create or replace PROCEDURE CONTRATO_MODIFICAR 
(
    v_id_contrato integer,
    v_documento_contrato varchar2,
    v_fecha_contrato date,
    v_tipo_contrato varchar2,
    v_id_empresa integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE contrato
    SET documento_contrato = v_documento_contrato,
    fecha_contrato = v_fecha_contrato,
    tipo_contrato = v_tipo_contrato,
    id_empresa = v_id_empresa
    WHERE id_contrato = v_id_contrato;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end CONTRATO_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE CONTRATO_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from contrato;
end CONTRATO_LISTAR;


------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP PAIS  -----------------------------------------------------------------------------

create sequence sec_pais
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;



create or replace PROCEDURE         "PAIS_ELIMINAR"
(
    v_id_pais VARCHAR2,
    v_salida out number

) IS 
BEGIN
  UPDATE pais 
  set estado_fila = '0'
  where v_id_pais = id_pais;
  commit;
  v_salida:=1;
  
   exception when others then v_salida:=0;


END PAIS_ELIMINAR;


create or replace PROCEDURE         "PAIS_AGREGAR"(
v_nombre_pais varchar2,
v_estado_fila char,
V_salida out number
) is 
BEGIN 
insert into pais(id_pais,nombre_pais,estado_fila)
values(SEC_PAIS.nextval ,v_nombre_pais,v_estado_fila);
commit;
  v_salida:=1; 

  exception when others then v_salida:=0;
end PAIS_AGREGAR;




create or replace PROCEDURE         "PAIS_MODIFICAR" (
    v_id_pais integer,
    v_nombre_pais varchar2,
    v_estado_fila char,
    v_salida out number

)is 
BEGIN
    update pais
    set nombre_pais = v_nombre_pais
    where id_pais = v_id_pais;
    commit;
    v_salida:=1;

    exception when others then v_salida:=0;
    
END PAIS_MODIFICAR;


create or replace PROCEDURE         "PAIS_LISTAR" (cur_listar out SYS_REFCURSOR)
is 
BEGIN
  open cur_listar for select * from pais where estado_fila = '1';
END PAIS_LISTAR;


------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP REGION  ---------------------------------------------------------------------------


create sequence sec_REGION
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE         "REGION_ELIMINAR"(

v_id_region Integer,
v_salida out number
)IS
BEGIN
    update region
    SET estado_fila = '0'
    where v_id_region = id_region;
    commit;
    v_salida:=1;
  
   exception when others then v_salida:=0;
    

END REGION_ELIMINAR;



create or replace PROCEDURE         "REGION_AGREGAR"(
v_nombre_region varchar2,
v_id_pais varchar2,
v_estado_fila char,
v_salida out number
)
IS 
BEGIN
insert into region(id_region,nombre_region,id_pais,estado_fila)
values (sec_region.NEXTVAL,v_nombre_region,v_id_pais,v_estado_fila);
commit;
  v_salida:=1; 

  exception when others then v_salida:=0;
END REGION_AGREGAR;




create or replace PROCEDURE         "REGION_MODIFICAR" (
    v_id_region integer,
    v_nombre_region varchar2,
    v_id_pais integer,
    v_estado_fila char,
    v_salida out number





)
IS
BEGIN
  update REGION
    set nombre_region = v_nombre_region
    where id_region = v_id_region;
    commit;
    v_salida:=1;

    exception when others then v_salida:=0;
END REGION_MODIFICAR;



create or replace PROCEDURE        "POSTULACION_LISTAR" (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from postulacion where estado_fila = '1';
end POSTULACION_LISTAR;






------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP CIUDAD  ---------------------------------------------------------------------------


create sequence sec_CIUDAD
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;







create or replace PROCEDURE         "CIUDAD_ELIMINAR"(

v_id_ciudad INTEGER,
v_salida out number



)IS 
BEGIN
  update ciudad
    SET estado_fila = '0'
    where v_id_ciudad = id_ciudad;
    commit;
    v_salida:=1;
    exception when others then v_salida:=0;
    
    
    
END CIUDAD_ELIMINAR;





create or replace PROCEDURE         "CIUDAD_AGREGAR"(

    v_nombre_ciudad varchar2,
    v_codigo_postal varchar2,
    v_id_region  varchar2,
    v_estado_fila char,
    V_salida out number
    ) is 
BEGIN
insert into ciudad(id_ciudad,nombre_ciudad,codigo_postal,id_region,estado_fila)
values (SEC_CIUDAD.nextval , v_nombre_ciudad,v_codigo_postal,v_id_region,v_estado_fila);
commit;
    v_salida:=1; 
    
    exception when others then v_salida:=0;
END CIUDAD_AGREGAR;




create or replace PROCEDURE          "CIUDAD_MODIFICAR"(

v_id_ciudad integer,
v_nombre_ciudad varchar2,
v_codigo_postal varchar2,
v_id_region integer,
v_estado_fila char,
V_salida out number


)is
BEGIN
  update ciudad
    set nombre_ciudad = v_nombre_ciudad
    where id_ciudad = v_id_ciudad;
    commit;
    v_salida:=1;

    exception when others then v_salida:=0;
END CIUDAD_MODIFICAR;


create or replace PROCEDURE           "CIUDAD_LISTAR" (cur_listar out SYS_REFCURSOR)
IS
BEGIN
  open cur_listar for select * from ciudad where estado_fila = '1';
END CIUDAD_LISTAR;


------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP calidad  ---------------------------------------------------------------------------

create sequence sec_calidad
  start with 1
  increment by 1
  maxvalue 99999
  minvalue 1;
  
  
  
create or replace PROCEDURE CALIDAD_ELIMINAR (v_id_calidad Integer, v_salida out number) is
begin 
    delete calidad
    WHERE id_calidad = v_id_calidad;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;



end CALIDAD_ELIMINAR;


create or replace PROCEDURE CALIDAD_AGREGAR 
(
    v_nombre varchar2,
    v_salida out number

) is
begin 
  insert into CALIDAD(id_calidad,descripcion_calidad) values(sec_cargo.nextval,v_nombre);
  commit;
  v_salida:=1;
  
  exception when others then v_salida:=0;

end CALIDAD_AGREGAR;


create or replace PROCEDURE CALIDAD_MODIFICAR (
    v_id Integer,
    v_nombre VARCHAR2,
    v_salida out number

) is
begin 
    UPDATE CALIDAD
    SET descripcion_calidad = v_nombre
    WHERE id_calidad = v_id;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end CALIDAD_MODIFICAR;

 

create or replace PROCEDURE CALIDAD_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from CALIDAD;
end CARGO_LISTAR;

------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP carga  ---------------------------------------------------------------------------

create sequence sec_carga
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE CARGA_ELIMINAR (v_id_carga Integer) is
begin 
    DELETE CARGA
    WHERE id_carga = v_id_carga;
    commit;

end CARGA_ELIMINAR;


create or replace PROCEDURE CARGA_AGREGAR
(
    v_capacidad_carga varchar2, 
    v_refrigeracion integer,
    v_tamano_carga varchar2,
    v_idsubasta_transportista integer,
    id_usuario integer,
    v_salida OUT NUMBER
) 
is
begin 
  insert into CARGA(ID_CARGA,CAPACIDAD_CARGA,REFRIGERACION,TAMANO_CARGA,ID_SUBASTA_TRANSPORTISTA,ID_USUARIO) 
  values(sec_producto.nextval,v_capacidad_carga,v_refrigeracion,v_tamano_carga,v_idsubasta_transportista,id_usuario);
  commit;
  v_salida:=1;
  exception when others then v_salida:=0;
end CARGA_AGREGAR;


 create or replace PROCEDURE CARGA_MODIFICAR (
    v_id_carga integer,
    v_capacidad_carga varchar2, 
    v_refrigeracion integer,
    v_tamano_carga varchar2,
    v_idsubasta_transportista integer,
    id_usuario integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE carga
    SET CAPACIDAD_CARGA = v_capacidad_carga,
    REFRIGERACION = v_refrigeracion,
    TAMANO_CARGA = v_tamano_carga,
    ID_SUBASTA_TRANSPORTISTA = v_idsubasta_transportista,
    ID_USUARIO = id_usuario
    WHERE id_carga = v_id_carga;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end CARGA_MODIFICAR;

 CREATE OR REPLACE EDITIONABLE PROCEDURE CARGA_LISTAR (cur_listar out SYS_REFCURSOR) 
is

begin
    open cur_listar for select * from PRODUCTO;
end CARGA_LISTAR;