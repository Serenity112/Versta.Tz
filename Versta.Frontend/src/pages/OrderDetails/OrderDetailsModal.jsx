import './OrderDetailsModal.css'

export default function OrderDetailsModal({ order, onClose }) {
  const formatDateTime = (iso) => new Date(iso).toLocaleString()

  return (
    <div className="modal-overlay">
      <div className="modal">
        <h2>Детали заказа</h2>

        <div className="modal-content">
          <Field label="ID заказа" value={order.orderId} />
          <Field label="Город отправителя" value={order.senderCity} />
          <Field label="Адрес отправителя" value={order.senderAddress} />
          <Field label="Город получателя" value={order.receiverCity} />
          <Field label="Адрес получателя" value={order.receiverAddress} />
          <Field label="Дата забора" value={formatDateTime(order.pickupDate)} />
          <Field label="Вес (кг)" value={order.weight} />
          <Field
            label="Дата создания заказа"
            value={formatDateTime(order.createdAt)}
          />
        </div>

        <button className="close-button" onClick={onClose}>
          Закрыть
        </button>
      </div>
    </div>
  )
}

function Field({ label, value }) {
  return (
    <div className="field">
      <span className="label">{label}</span>
      <span className="value">{value}</span>
    </div>
  )
}
