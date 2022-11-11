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


create or replace PROCEDURE                   "USUARIO_ELIMINAR" (v_correo varchar2, v_salida out number) is
begin 
    UPDATE usuario
    SET usuario_vigente = '0'
    WHERE correo_usuario = v_correo;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end USUARIO_ELIMINAR;


create or replace PROCEDURE                   "USUARIO_AGREGAR" 
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
    v_salida OUT NUMBER

) is
begin 
  insert into USUARIO(id_usuario,NUMERO_IDENTIFICACION_USUARIO,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,usuario_vigente,fecha_creacion_usuario,administrador_usuario,id_cargo,id_empresa) 
  values(sec_usuario.nextval,v_numero_identeificacion_usuario,v_nombre_usuario,v_direccion_usuario,v_telefono_usuario,v_correo_usuario,v_contrasena_usuario,v_usuario_vigente,v_fecha_creacion_usuario,v_administrador_usuario,v_id_cargo,v_id_empresa);
  commit;
  v_salida:=1; 

  exception when others then v_salida:=0;

end USUARIO_AGREGAR;


create or replace PROCEDURE                   "USUARIO_MODIFICAR" (
    v_numero_identeificacion_usuario varchar2,
    v_nombre_usuario varchar2,
    v_direccion_usuario varchar2,
    v_telefono_usuario varchar2,
    v_correo_usuario varchar2,
    v_contrasena_usuario varchar2,
    v_administrador_usuario char,
    v_id_cargo Integer,
    v_id_empresa Integer,
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
    id_empresa = v_id_empresa
    WHERE NUMERO_IDENTIFICACION_USUARIO = v_numero_identeificacion_usuario;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;


 

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


create or replace PROCEDURE                   "PRODUCTO_ELIMINAR" (v_id_producto varchar2,v_salida out number) is
begin 
    UPDATE PRODUCTO
    SET estado_fila = '0'
    WHERE id_producto = v_id_producto;
    commit;
    v_salida:=1;
    exception when others then v_salida:=0;
    
end PRODUCTO_ELIMINAR; 


create or replace PROCEDURE                   "PRODUCTO_AGREGAR" 
(
    v_nombre_producto varchar2, 
    v_cantidad_producto float,
    v_precio_producto integer,
    v_imagen_producto varchar2,
    v_id_calidad integer,
    v_saldo_producto char,
    v_id_usuario integer,
    v_estado_fila char,
    v_descripcion_producto varchar2,
    v_salida OUT NUMBER
) 
is
begin 
  insert into PRODUCTO(id_producto,nombre_producto,cantidad_producto,precio_producto,imagen_producto,id_usuario,id_calidad,estado_fila,descripcion_producto) 
  values(sec_producto.nextval,v_nombre_producto,v_cantidad_producto,v_precio_producto,v_imagen_producto,v_id_usuario,v_id_calidad,v_estado_fila,v_descripcion_producto);
  commit;
  v_salida:=1;
  exception when others then v_salida:=0;
end ;


create or replace PROCEDURE                   "PRODUCTO_MODIFICAR" (
    v_id_producto varchar2,
    v_nombre_producto varchar2, 
    v_cantidad_producto integer,
    v_precio_producto integer,
    v_imagen_producto varchar2,
    v_id_calidad integer,
    v_saldo_producto char,
    v_id_usuario integer,
    v_descripcion_producto varchar2,
    v_salida OUT NUMBER

) is
begin 
    UPDATE producto
    SET nombre_producto = v_nombre_producto,
    cantidad_producto = v_cantidad_producto,
    precio_producto = v_precio_producto,
    imagen_producto = v_imagen_producto,
    id_usuario = v_id_usuario,
    saldo_producto = v_saldo_producto,
    id_calidad = v_id_calidad,
    descripcion_producto = v_descripcion_producto
    WHERE id_producto = v_id_producto;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

 CREATE OR REPLACE EDITIONABLE PROCEDURE PRODUCTO_LISTAR (cur_listar out SYS_REFCURSOR) 
is

begin
    open cur_listar for select * from PRODUCTO;
end PRODUCTO_LISTAR;

create or replace PROCEDURE PRODUCTO_SALDO
(
    v_id_producto varchar2,
    v_saldo_producto char,
    v_salida OUT NUMBER

) is
begin 
    UPDATE producto
    SET saldo_producto = v_saldo_producto
    WHERE id_producto = v_id_producto;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;


end PRODUCTO_SALDO;

------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP LOGIN -----------------------------------------------------------------------------
create or replace PROCEDURE LOGIN
(
    v_correo varchar2,
    v_contrasena varchar2,
    cur out SYS_REFCURSOR
)
is
begin
    open cur for select u.nombre_usuario,c.nombre_cargo,u.correo_usuario,u.fecha_sesion_usuario,e.razon_social_empresa,u.id_usuario from usuario u, cargo c ,empresa e
    where u.id_empresa = e.id_empresa and  u.id_cargo = c.id_cargo and u.correo_usuario = v_correo and u.contrasena_usuario = v_contrasena and u.usuario_vigente = '1';
    update usuario 
    set fecha_sesion_usuario = sysdate
    where correo_usuario=v_correo AND CONTRASENA_USUARIO = v_contrasena AND USUARIO_VIGENTE = '1';
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
    v_duns_empresa varchar2,
    v_razon_social_empresa varchar2,
    v_direccion_empresa varchar2,
    v_giro_empresa varchar2,
    v_id_tipo_empresa integer,
    v_id_ciudad integer,
    v_id_region integer,
    v_id_pais integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into EMPRESA(id_empresa,duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad,id_region,id_pais,estado_fila) 
  values(sec_empresa.nextval,v_duns_empresa,v_razon_social_empresa,v_direccion_empresa,v_giro_empresa,v_id_tipo_empresa,v_id_ciudad,v_id_region,v_id_pais,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end EMPRESA_AGREGAR;


create or replace PROCEDURE EMPRESA_MODIFICAR (
    v_id_empresa integer,
    v_duns_empresa varchar2,
    v_razon_social_empresa varchar2,
    v_direccion_empresa varchar2,
    v_giro_empresa varchar2,
    v_id_tipo_empresa integer,
    v_id_ciudad integer,
    v_id_region integer,
    v_id_pais integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE empresa
    SET duns_empresa = v_duns_empresa,
    razon_social_empresa = v_razon_social_empresa,
    direccion_empresa = v_direccion_empresa,
    giro_empresa = v_giro_empresa,
    id_tipo_empresa = v_id_tipo_empresa,
    id_ciudad = v_id_ciudad,
    id_region = v_id_region,
    id_pais = v_id_pais
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
----------------------------------------SP carrito -----------------------------------------------------------------------------


create sequence sec_carrito
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE CARRITO_ELIMINAR (v_id_carrito integer, v_salida out number) is
begin 
    UPDATE carrito
    SET estado_fila = '0'
    WHERE v_id_carrito = id_carrito;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end CARRITO_ELIMINAR;


create or replace PROCEDURE CARRITO_AGREGAR 
(
    v_fecha_carrito date,
    v_monto_carrito integer,
    v_id_producto varchar2,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into carrito(id_carrito,fecha_carrito,monto_carrito,id_producto,estado_fila) 
  values(sec_carrito.nextval,v_fecha_carrito,v_monto_carrito,v_id_producto,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end CARRITO_AGREGAR;


create or replace PROCEDURE CARRITO_MODIFICAR (
    v_id_carrito integer,
    v_fecha_carrito date,
    v_monto_carrito integer,
    v_id_producto varchar2,
    v_salida OUT NUMBER

) is
begin 
    UPDATE carrito
    SET fecha_carrito = v_fecha_carrito,
    monto_carrito = v_monto_carrito,
    id_producto = v_id_producto
    WHERE id_carrito = v_id_carrito;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end CARRITO_MODIFICAR;

 

CREATE OR REPLACE EDITIONABLE PROCEDURE CARRITO_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from carrito;
end CARRITO_LISTAR;

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
    set estado_fila = '0'
    WHERE v_id_pedido = id_pedido;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end PEDIDO_ELIMINAR;


create or replace PROCEDURE PEDIDO_AGREGAR
(
    v_descripcion_pedido varchar2,
    v_fecha_sla_pedido varchar2,
    v_id_usuario integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into pedido(id_pedido,descripcion_pedido,fecha_sla_pedido,id_usuario,estado_fila) 
  values(sec_pedido.nextval,v_descripcion_pedido,v_fecha_sla_pedido,v_id_usuario,v_estado_fila);
  commit;
  v_salida:=1; 

  exception when others then v_salida:=0;

end PEDIDO_AGREGAR;


create or replace PROCEDURE PEDIDO_MODIFICAR (
    v_id_pedido integer,
    v_descripcion_pedido varchar2,
    v_fecha_sla_pedido varchar2,
    v_id_usuario integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE pedido
    SET descripcion_pedido = v_descripcion_pedido,
    fecha_sla_pedido = v_fecha_sla_pedido,
    id_usuario = v_id_usuario
    WHERE id_pedido = v_id_pedido;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;


end PEDIDO_MODIFICAR;
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
    DELETE postulacion
    WHERE v_id_postulacion = id_postulacion;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end POSTULACION_ELIMINAR;


create or replace PROCEDURE POSTULACION_AGREGAR 
(
    v_descripcion_postulacion varchar2,
    v_estado_postulacion varchar2,
    v_id_venta integer,
    v_id_usuario integer,
    v_id_producto varchar2,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into postulacion(id_postulacion,descripcion_postulacion,estado_postulacion,id_venta,id_usuario,ID_PRODUCTO,estado_fila) 
  values(sec_postulacion.nextval,v_descripcion_postulacion,v_estado_postulacion,v_id_venta,v_id_usuario,v_id_producto,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end POSTULACION_AGREGAR;


create or replace PROCEDURE POSTULACION_MODIFICAR 
(
    v_id_postulacion integer,
    v_descripcion_postulacion varchar2,
    v_estado_postulacion varchar2,
    v_id_venta integer,
    v_id_usuario integer,
    v_id_producto varchar2,
    v_salida OUT NUMBER

) is
begin 
    UPDATE postulacion
    SET descripcion_postulacion = v_descripcion_postulacion,
    estado_postulacion = v_estado_postulacion,
    id_venta = v_id_venta,
    id_usuario = v_id_usuario,
    id_producto = v_id_producto
    WHERE id_postulacion = v_id_postulacion;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;

end POSTULACION_MODIFICAR;

create or replace PROCEDURE POSTULACION_ACEPTAR
(
    v_id_postulacion char,
    v_salida OUT NUMBER

) is
begin 
    UPDATE postulacion
    SET estado_fila = '1',
    estado_postulacion = 'Aceptada'
    WHERE id_postulacion = v_id_postulacion;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end POSTULACION_ACEPTAR;

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
    v_id_venta integer,
    v_id_usuario integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into reporte(id_reporte,descripcion_reporte,productos_entregados_reporte,productos_perdidos_reporte,productos_restantes_reporte,id_venta,id_usuario,estado_fila) 
  values(sec_reporte.nextval,v_descripcion_reporte,v_productos_entregados_reporte,v_productos_perdidos_reporte,v_productos_restantes_reporte,v_id_venta,v_id_usuario,v_estado_fila);
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
    v_id_venta integer,
    v_id_usuario integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE reporte
    SET descripcion_reporte = v_descripcion_reporte,
    productos_entregados_reporte = v_productos_entregados_reporte,
    productos_perdidos_reporte = v_productos_perdidos_reporte,
    productos_restantes_reporte = v_productos_restantes_reporte,
    id_venta = v_id_venta,
    id_usuario = v_id_usuario
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
    v_id_venta integer,
    v_CANTIDAD_PRODUCTO_RESUMEN float,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into resumen_venta(id_resumen,monto_neto_venta,descripcion_resumen,id_venta,CANTIDAD_PRODUCTO_RESUMEN,estado_fila) 
  values(sec_resumen_venta.nextval,v_monto_neto_venta,v_descripcion_resumen,v_id_venta,v_CANTIDAD_PRODUCTO_RESUMEN,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end RESUMEN_VENTA_AGREGAR;


create or replace PROCEDURE RESUMEN_VENTA_MODIFICAR 
(
    v_id_resumen integer,
    v_monto_neto_venta integer,
    v_descripcion_resumen varchar2,
    v_id_venta integer,
    v_CANTIDAD_PRODUCTO_RESUMEN float,
    v_salida OUT NUMBER

) is
begin 
    UPDATE resumen_venta
    SET monto_neto_venta = v_monto_neto_venta,
    descripcion_resumen = v_descripcion_resumen,
    id_venta= v_id_venta,
    CANTIDAD_PRODUCTO_RESUMEN = v_CANTIDAD_PRODUCTO_RESUMEN
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
----------------------------------------SP venta -----------------------------------------------------------------------------

create sequence sec_venta
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;


create or replace PROCEDURE VENTA_ELIMINAR (v_id_venta integer, v_salida out number) is
begin 
    UPDATE venta
    SET estado_fila = '0'
    WHERE id_venta = v_id_venta;
    commit;
    v_salida:=1;

  exception when others then v_salida:=0;

end VENTA_ELIMINAR;

create or replace PROCEDURE                   "VENTA_AGREGAR" 
(
    v_id_venta integer,
    v_descripcion varchar2,
    v_estado_venta varchar2,
    v_monto_bruto integer,
    v_iva integer,
    v_monto_neto integer,
    v_fecha date,
    v_tipo_venta char,
    v_id_usuario integer,
    v_cantidad_venta integer,
    v_monto_transporte integer,
    v_monto_aduanas integer,
    v_pago_servicio integer,
    v_comision_venta integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into venta(id_venta,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,fecha_venta,estado_fila,tipo_venta,id_usuario,CANTIDAD_VENTA,MONTO_TRANSPORTE,MONTO_ADUANAS,PAGO_SERVICIO,COMISION_VENTA) 
  values(v_id_venta,v_descripcion,v_estado_venta,v_monto_bruto,v_iva,v_monto_neto,v_fecha,v_estado_fila,v_tipo_venta,v_id_usuario,v_cantidad_venta,v_monto_transporte,v_monto_aduanas,v_pago_servicio,v_comision_venta);
  commit;
  v_salida:=1; 

  exception when others then v_salida:=0;

end VENTA_AGREGAR;

create or replace PROCEDURE VENTA_MODIFICAR 
(
    v_id_venta integer,
    v_descripcion varchar2,
    v_estado_venta varchar2,
    v_monto_bruto integer,
    v_iva integer,
    v_monto_neto integer,
    v_fecha date,
    v_tipo_venta char,
    v_id_usuario integer,
    v_cantidad_venta integer,
    v_monto_transporte integer,
    v_monto_aduanas integer,
    v_pago_servicio integer,
    v_comision_venta integer,
    v_salida OUT NUMBER

) is
begin 
    UPDATE venta
    SET descripcion_venta = v_descripcion,
    estado_venta = v_estado_venta,
    monto_bruto_venta = v_monto_bruto,
    iva = v_iva,
    monto_neto_venta = v_monto_neto,
    fecha_venta = v_fecha,
    tipo_venta = v_tipo_venta,
    id_usuario = v_id_usuario,
    cantidad_venta = v_cantidad_venta,
    monto_transporte = v_monto_transporte,
    monto_aduanas = v_monto_aduanas,
    pago_servicio = v_pago_servicio,
    comision_venta = v_comision_venta
    WHERE id_venta = v_id_venta;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;


end VENTA_MODIFICAR;

CREATE OR REPLACE EDITIONABLE PROCEDURE VENTA_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from venta;
end VENTA_LISTAR;
------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP contrato -----------------------------------------------------------------------------


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
    v_id_contrato varchar2,
    v_documento_contrato varchar2,
    v_fecha_contrato date,
    v_tipo_contrato varchar2,
    v_id_empresa integer,
    v_estado_fila char,
    v_salida OUT NUMBER

) is
begin 
  insert into contrato(id_contrato,documento_contrato,fecha_contrato,tipo_contrato,id_empresa,estado_fila) 
  values(v_id_contratol,v_documento_contrato,v_fecha_contrato,v_tipo_contrato,v_id_empresa,v_estado_fila);
  commit;
  v_salida:=1; 
  
  exception when others then v_salida:=0;

end CONTRATO_AGREGAR;

create or replace PROCEDURE CONTRATO_MODIFICAR 
(
    v_id_contrato varchar2,
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

create or replace PROCEDURE PAIS_ELIMINAR
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

create or replace PROCEDURE PAIS_AGREGAR
(
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

create or replace PROCEDURE PAIS_MODIFICAR 
(
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

create or replace PROCEDURE PAIS_LISTAR (cur_listar out SYS_REFCURSOR)
is 
BEGIN
  open cur_listar for select * from pais;
END PAIS_LISTAR;
-----------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP REGION  ---------------------------------------------------------------------------
create sequence sec_REGION
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;

create or replace PROCEDURE REGION_ELIMINAR
(
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

create or replace PROCEDURE REGION_AGREGAR
(
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

create or replace PROCEDURE REGION_MODIFICAR
(
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

create or replace PROCEDURE REGION_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from region;
end REGION_LISTAR;
------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP CIUDAD  ---------------------------------------------------------------------------
create sequence sec_CIUDAD
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;

create or replace PROCEDURE CIUDAD_ELIMINAR
(
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

create or replace PROCEDURE CIUDAD_AGREGAR
(
    v_nombre_ciudad varchar2,
    v_codigo_postal varchar2,
    v_id_region  varchar2,
    v_estado_fila char,
    V_salida out number
)is 
BEGIN
    insert into ciudad(id_ciudad,nombre_ciudad,codigo_postal,id_region,estado_fila)
    values (SEC_CIUDAD.nextval , v_nombre_ciudad,v_codigo_postal,v_id_region,v_estado_fila);
    commit;
        v_salida:=1; 
    
    exception when others then v_salida:=0;
END CIUDAD_AGREGAR;

create or replace PROCEDURE CIUDAD_MODIFICAR
(
    v_id_ciudad integer,
    v_nombre_ciudad varchar2,
    v_codigo_postal varchar2,
    v_id_region integer,
    v_estado_fila char,
    v_salida out number
)is
BEGIN
  update ciudad
    set nombre_ciudad = v_nombre_ciudad
    where id_ciudad = v_id_ciudad;
    commit;
    v_salida:=1;

    exception when others then v_salida:=0;
END CIUDAD_MODIFICAR;


create or replace PROCEDURE CIUDAD_LISTAR(cur_listar out SYS_REFCURSOR)
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
    UPDATE CALIDAD
    SET ESTADO_FILA  = '0'
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
  insert into CALIDAD(id_calidad,descripcion_calidad) values(sec_calidad.nextval,v_nombre);
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
end CALIDAD_LISTAR;

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
    v_idsubasta integer,
    id_usuario integer,
    v_salida OUT NUMBER
) 
is
begin 
  insert into CARGA(ID_CARGA,CAPACIDAD_CARGA,REFRIGERACION_carga,TAMANO_CARGA,ID_SUBASTA,ID_USUARIO) 
  values(sec_producto.nextval,v_capacidad_carga,v_refrigeracion,v_tamano_carga,v_idsubasta,id_usuario);
  commit;
  v_salida:=1;
  exception when others then v_salida:=0;
end CARGA_AGREGAR;

create or replace PROCEDURE CARGA_MODIFICAR (
    v_id_carga integer,
    v_capacidad_carga varchar2, 
    v_refrigeracion integer,
    v_tamano_carga varchar2,
    v_idsubasta integer,
    id_usuario integer,
    v_salida OUT NUMBER
) is
begin 
    UPDATE carga
    SET CAPACIDAD_CARGA = v_capacidad_carga,
    REFRIGERACION_carga = v_refrigeracion,
    TAMANO_CARGA = v_tamano_carga,
    ID_SUBASTA = v_idsubasta,
    ID_USUARIO = id_usuario
    WHERE id_carga = v_id_carga;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;
end CARGA_MODIFICAR;

 CREATE OR REPLACE EDITIONABLE PROCEDURE CARGA_LISTAR (cur_listar out SYS_REFCURSOR) 
is

begin
    open cur_listar for select * from carga;
end CARGA_LISTAR;
------------------------------------------------------------------------------------------------------------------------------
----------------------------------------SP subasta  ---------------------------------------------------------------------------

create sequence sec_subasta
  start with 1
  increment by 1
  maxvalue 99999999999999999999
  minvalue 1;

create or replace PROCEDURE SUBASTA_AGREGAR
(
    v_monto integer,
    v_id_venta integer,
    v_id_usuario integer,
    v_fecha_subasta date,
    v_estado_fila char,
    v_salida OUT varchar2

) is
begin 
  insert into subasta(id_subasta,monto_subasta,id_venta,fecha_subasta,estado_fila,id_usuario) 
  values(sec_subasta.nextval,v_monto,v_id_venta,v_fecha_subasta,v_estado_fila,v_id_usuario);
  commit;
  v_salida:=sec_subasta.CURRVAL; 

  exception when others then v_salida:=0;

end SUBASTA_AGREGAR;

create or replace PROCEDURE SUBASTA_MODIFICAR (
    v_id_subasta integer,
    v_monto integer,
    v_id_venta integer,
    v_id_usuario integer,
    v_fecha_subasta date,
    v_salida OUT NUMBER
) is
begin 
    UPDATE subasta
    SET monto_subasta = v_monto,
    id_venta = v_id_venta,
    fecha_subasta = v_fecha_subasta,
    ID_USUARIO = v_id_usuario
    WHERE id_subasta = v_id_subasta;
    commit;
    v_salida:=1;
  
  exception when others then v_salida:=0;
end SUBASTA_MODIFICAR;

create or replace PROCEDURE SUBASTA_LISTAR (cur_listar out SYS_REFCURSOR) 
is
begin
  open cur_listar for select * from subasta;
end SUBASTA_LISTAR;