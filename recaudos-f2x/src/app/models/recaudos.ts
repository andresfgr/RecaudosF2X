export class Recaudos {
    idRecaudos: number;
    estacion:  string;
    sentido: string;
    hora: number;
    categoria: string;
    cantidad: number; 
    valorTabulado: number;
    fecha: string;

    constructor(
        idRecaudos: number,
        estacion:  string,
        sentido: string,
        hora: number,
        categoria: string,
        cantidad: number, 
        valorTabulado: number,
        fecha: string) {
        this.idRecaudos = idRecaudos;
        this.estacion = estacion;
        this.sentido = sentido;
        this.hora = hora;
        this.categoria = categoria;
        this.cantidad = cantidad;
        this.valorTabulado = valorTabulado;
        this.fecha = fecha;
    }
}