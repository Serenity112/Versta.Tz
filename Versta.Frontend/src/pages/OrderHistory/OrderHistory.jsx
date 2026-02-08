import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import OrderDetailsModal from '../OrderDetails/OrderDetailsModal'
import './OrderHistory.css'

export default function OrderHistory() {
  const [orders, setOrders] = useState([])

  const [loading, setLoading] = useState(true)

  const [error, setError] = useState(null)

  const [selectedOrder, setSelectedOrder] = useState(null)

  useEffect(() => {
    const loadOrders = async () => {
      try {
        const response = await fetch('http://localhost:5102/api/orders')

        if (!response.ok) {
          throw new Error('Ошибка загрузки заказов')
        }

        const data = await response.json()
        setOrders(data.orders)
      } catch (err) {
        setError(err.message)
      } finally {
        setLoading(false)
      }
    }

    loadOrders()
  }, [])

  const formatDate = (iso) => new Date(iso).toLocaleDateString()

  if (loading) return <p>Загрузка...</p>
  if (error) return <p className="error">{error}</p>

  return (
    <div className="order-history">
      <h1>История заказов</h1>

      <table className={`orders-table ${selectedOrder ? 'disabled' : ''}`}>
        <thead>
          <tr>
            <th>ID заказа</th>
            <th>Город отправителя</th>
            <th>Адрес отправителя</th>
            <th>Город получателя</th>
            <th>Адрес получателя</th>
            <th>Дата забора</th>
            <th>Вес (кг)</th>
          </tr>
        </thead>

        <tbody>
          {orders.map(order => (
            <tr
              key={order.orderId}
              onClick={() => setSelectedOrder(order)}>
              <td>{order.orderId}</td>
              <td>{order.senderCity}</td>
              <td>{order.senderAddress}</td>
              <td>{order.receiverCity}</td>
              <td>{order.receiverAddress}</td>
              <td>{formatDate(order.pickupDate)}</td>
              <td>{order.weight}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <nav className="nav-links">
        <Link to="/orders/create" className="nav-link">Создать заказ</Link>
      </nav>

      {selectedOrder && (<OrderDetailsModal order={selectedOrder} onClose={() => setSelectedOrder(null)} />)}
    </div>
  )
}
