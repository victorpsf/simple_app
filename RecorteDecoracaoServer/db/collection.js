const Collection = function ({values = [], fields = []}) {
  const info = function (data = []) {
    return {
      first: 0,
      last: data.length > 0 ? data.length - 1: 0
    }
  }

  this.FieldsResult = function () 
  { return fields }

  this.ToArray = function () 
  { return values; }

  this.Filter = function (callback) 
  { return new Collection(values.filter(callback)) }

  this.Map = function (callback)
  { return new Collection(values.map(callback)) }

  this.Where = function (callback)
  { return this.filter(callback) }

  this.Sort = function (callback)
  { return new Collection(values.sort(callback)) }

  this.First = function () {
    const { first, last } = info(values)

    return values[first] || null
  }

  this.Last = function () {
    const { first, last } = info(values)

    return values[last] || null
  }

  this.Search = function (callback) 
  { return values.find(callback) }

  this.Count = function () 
  { return values.length }
}

export default Collection;