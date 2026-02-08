import { createBrowserRouter } from 'react-router-dom'
import CreateOrder from '../pages/CreateOrder/CreateOrder'
import OrderHistory from '../pages/OrderHistory/OrderHistory'

export const router = createBrowserRouter([
  {
    path: '/orders/create',
    element: <CreateOrder />
  },

  {
    path: '/orders/history',
    element: <OrderHistory />
  },
])
