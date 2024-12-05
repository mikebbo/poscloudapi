import React, { useEffect, useState } from 'react';

function ProductList() {
  const [products, setProducts] = useState([]);
  useEffect(() => {
    fetch('http://localhost:5046/api/Product/')
      .then((response) => response.json())
      .then((data) => setProducts(data))
      .catch((error) => {
        console.error('Error fetching the product', error);
      });
  }, []);
  return (
    <div className='container '>
      <h1> ProductList</h1>

      <table className='table table-stryped '>
        <thead className='thread-dark'>
          <tr>
            <th></th>
            <th></th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {products.map((item) => (
            <tr key={item.Id}>
              <td>{item.Id}</td>
              <td>{item.Name}</td>
              <td>{item.Description}</td>
              <td>{item.quant}</td>
              <td>{item.buyPrice}</td>
              <td>{item.sellPrice}</td>
              <td>{item.dateCreated}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ProductList;
