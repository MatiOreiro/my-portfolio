use "DeviceService"

// A
db.Obligatorio.find(
  { IdRepara: NumberInt(1) },  
  { _id: 0, IdRepara: 1, Eventos: 1 } 
)

// B
db.Obligatorio.find({
  $or: [
    { "Eventos.Descripcion": { $regex: "placa", $options: "i" } },
    { "Eventos.NotasTecnico": { $regex: "placa", $options: "i" } }
  ]
})

// C
db.Obligatorio.find({
  Eventos: {
    $elemMatch: {
      Adjuntos: { $elemMatch: { Tipo: "Imagen" } }
    }
  }
})

// D
db.Obligatorio.aggregate([
  { $unwind: "$Eventos" },
  { $match: { "Eventos.Descripcion": "Reemplazo de pieza" } },
  { $group: { _id: "$IdRepara" } },
  { $count: "TotalReparacionesConReemplazo" }
])



db.Obligatorio.find().pretty()
