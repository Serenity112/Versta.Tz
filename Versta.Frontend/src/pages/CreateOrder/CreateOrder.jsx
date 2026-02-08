import { useState } from 'react'
import { Link } from 'react-router-dom'
import './CreateOrder.css'

export default function CreateOrder() {
  const [form, setForm] = useState({
    senderCity: '',
    senderAddress: '',
    receiverCity: '',
    receiverAddress: '',
    pickupDate: '',
    weight: ''
  })

  const [errors, setErrors] = useState({})
  const [loading, setLoading] = useState(false)
  const [successOrderId, setSuccessOrderId] = useState(null)
  const [serverError, setServerError] = useState(null)

  const handleChange = (e) => {
    const { name, value } = e.target
    setForm(prev => ({ ...prev, [name]: value }))
    setErrors(prev => ({ ...prev, [name]: '' }))
  }

  const validate = () => {
    const newErrors = {}
    Object.entries(form).forEach(([key, value]) => {
      if (!value || value.trim() === '') {
        newErrors[key] = 'Это поле обязательно'
      }
    })
    setErrors(newErrors)
    return Object.keys(newErrors).length === 0
  }

  const toUtcIsoDate = (dateString) => {
    const [year, month, day] = dateString.split('-')
    return new Date(Date.UTC(year, month - 1, day)).toISOString()
  }

  const parseProblemDetails = async (response) => {
    try {
      const data = await response.json()

      if (data.errors) {
        return Object.values(data.errors).flat().join(', ')
      }

      return data.detail || data.title || 'Ошибка сервера'
    } catch {
      return 'Ошибка сервера'
    }
  }


  const handleSubmit = async (e) => {
    e.preventDefault()

    setServerError(null)

    setSuccessOrderId(null)

    if (!validate()) {
      return
    }

    setLoading(true)

    try {
      const payload = {
        ...form,
        pickupDate: toUtcIsoDate(form.pickupDate),
        weight: Number(form.weight)
      }

      const response = await fetch('http://localhost:5102/api/orders', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      })

      if (!response.ok) {
        const errorMessage = await parseProblemDetails(response)
        throw new Error(errorMessage)
      }

      const data = await response.json()
      setSuccessOrderId(data.orderId)

      setForm({
        senderCity: '',
        senderAddress: '',
        receiverCity: '',
        receiverAddress: '',
        pickupDate: '',
        weight: ''
      })
    } catch (err) {
      setServerError(err.message)
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="create-order">
      <h1>Создание заказа</h1>

      <form className="order-form" onSubmit={handleSubmit}>

        <div className="input-wrapper">
          <input
            type="text"
            name="senderCity"
            placeholder="Город отправителя"
            value={form.senderCity}
            onChange={handleChange} />
          <span className="error">{errors.senderCity}</span>
        </div>

        <div className="input-wrapper">
          <input
            type="text"
            name="senderAddress"
            placeholder="Адрес отправителя"
            value={form.senderAddress}
            onChange={handleChange} />
          <span className="error">{errors.senderAddress}</span>
        </div>

        <div className="input-wrapper">
          <input
            type="text"
            name="receiverCity"
            placeholder="Город получателя"
            value={form.receiverCity}
            onChange={handleChange} />
          <span className="error">{errors.receiverCity}</span>
        </div>

        <div className="input-wrapper">
          <input
            type="text"
            name="receiverAddress"
            placeholder="Адрес получателя"
            value={form.receiverAddress}
            onChange={handleChange} />
          <span className="error">{errors.receiverAddress}</span>
        </div>

        <div className="input-wrapper">
          <input
            type="date"
            name="pickupDate"
            value={form.pickupDate}
            onChange={handleChange} />
          <span className="error">{errors.pickupDate}</span>
        </div>

        <div className="input-wrapper">
          <input
            type="number"
            name="weight"
            placeholder="Вес отправления (кг)"
            value={form.weight}
            onChange={handleChange}
          />
          <span className="error">{errors.weight}</span>
        </div>

        <button type="submit" disabled={loading}>
          {loading ? 'Создание' : 'Создать'}
        </button>
      </form>

      {serverError &&
        <p className="server-error">{serverError}</p>}

      {successOrderId && (
        <p className="success">
          Заказ успешно создан, ID: <b>{successOrderId}</b>
        </p>
      )}

      <nav className="nav-links">
        <Link to="/orders/history" className="nav-link">История заказов</Link>
      </nav>
    </div>
  )
}
