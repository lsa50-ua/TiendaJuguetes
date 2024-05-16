# P-HADA-G3

## Descripción : 
	Tienda de juguetes online llamada HADA TOYs en la que habrá juguetes de varias categorías y con un carrito 
	en el que se almacenará lo que se lleva de pedido.

## Parte Pública:
	Página inicial con titulo y datos de contacto y una lista con los juguetes más vendidos

## Listado EN Pública: 
	ENArticulo
	ENUsuario

## Parte Privada:
	Podrás tener acceso al carrito y ver tu historial de pedidos, además de tener un área privada donde cambiar los datos
	del usuario (nombre, dirección , tarjeta ...).

## Listado EN Privada:
	ENCarritos -> asociado a un usuario (
		- solo puede haber un carrito activo 
		- hay tantos carritos como el usuario desee, los va añadiendo a la lista
		- cuando se cierra la sesión si hay un carrito activo se guarda en la lista, pero como desactivado 
		- BOOLEANO que indica si el carrito está activo o no (si no está activo pregunta al usuario si quiere recuperarlo, 
			si te digo que no LOS BORRO) 
	)
	ENUsuario
	ENCiudad
	ENComunidad
	ENProvincia
	ENLocalidad
	
	ENPedido (copia de un carrito completado)
	ENLinped 
	ENFactura
	ENStock
	ENCategoria ()
	ENMarca

## Posibles mejoras:
	- Internacionalización (no recomendada por el profe xd )
	- Enlace para redes sociales 
	- Cada usuario puede vender artículos
	- Valoraciones para cada producto (estrellas y comentarios)
	- ENPopulares (búsqueda en ENPedido para ver cuales son los que más se han vendido)
	

El esquema de la base de datos se encuentra en el directorio principal del proyecto, bajo el nombre de archivo "Esquema dbd toys.pdf"

27/05/2022
Hoy se entrega la practica. Nuestro proyecto es una tienda de juguetes, tal y como pensamos en un principio. Ha habido cambios en la cantidad de ENCADs empleados (siguen siendo 10), pero ya no tenemos marca, ni localidad (irrelevante y demasiado grande), ni stock (se incluye en una columna de articulo), ni ciudad (solo contamos con provincias).

Hemos tenido problemas en general, sobre todo con Sarah, ya que nos ha costado que trabaje todo lo que nos hubiera gustado y nos hemos sentido algo asfixiados por el hecho de ser, realmente, 4 personas en el grupo. Tambien consideramos haber tenido problemas de planificacion, ya que al final hemos ido deprisa y corriendo y, sinceramente, creemos que con 3 dias mas, nos podria haber quedado un proyecto mucho mejor.

Para ejecutar la practica, simplemente deberán abrir la solución, compilarla y ejecutarla. El usuario y contraseña del usuario administrador es: Usuario: admin@gmail.com Contraseña: 111

Esta es la unica cuenta desde la que se habilita la opcion de añadir productos nuevos a la base de datos.

Miguel: Buscó todas las imagenes, creo el esquema de la base de datos (provisional, la base de datos no es exactamente igual), principalmente el hizo el TiendaJuguetesMaster.Master, aunque Luis y Mario tambien tuvieron influencia. Tambien se encargo de los estilos de todo (global_style.css). Default.aspx, con sus estilos y Articulo.aspx. Para ello, necesitó seguir con los encads de articulo que habia empezado Alvaro. También le dió estilos a esa pagina. Por ultimo, creo Categoria.aspx, con los estilos correspondientes y los ENCADs correspondientes con Mario.

Alvaro: Paricipó junto a Sarah en la primera versión de la página, creo toda la pagina de articulo, junto a sus ENCADS, así como los de linCarrito. También retocó la base de datos para ajustarla a sus encads. También empezó con los encads de articulo, tarea con la cual siguió Miguel.

Mario: Creó la base de datos, con sus tablas y sus propiedades. Tambien creó los encads de comunidad, provincia, pedido, linpedido, factura y categoria (este ultimo con Miguel). Además, creó AgregarProducto.aspx y Pago.aspx. También hizo la funcionalidad de "Filtrar por", que se usa tanto en Default.aspx como en Categoria.aspx.

Sarah: Participó en la primera versión de la pagina, creo la primera version de los ENCADs de usuario e hizo el footer.

Luis: Creó los ENCADs de usuario, y en los de provincia creó un metodo para rellenar un dropdownlist desde la base de datos. También hizo las validaciones de usuario, que modifican el menuitems (desactivan area privada si no hay usuario, y si hay usuario administrador activan añadir productos). Creo la sesion de usuario, usada en Pago.aspx y en carrito.aspx y creo los estilos de los formularios.
