var React = require('react');

//Example: /<PlayerStat  name="Russell Wesbrook />
// script must be at the bottom so that it can render from elements still existing in the DOM before the script becomes the head and there is no more "document".
//IN REACT,FUNCTION CALLS MUST BE DONE WITHIN THE "{}" BRACKETS
function getStateFromDotNetModel(data) {
    try {
        return data;
    } catch (e) {
        throw new Error("ERROR: Could not Retrieve Model JSON from .Net Server");
    }
}

function getImmutableClone(object, property, val) {
    const objectClone = Object.assign({}, object);
    if (typeof(property) != "string") {
        throw new Error("Error: object not changed because 'property' wasn't a string");
    }
    if (typeof(val) !== typeof(objectClone[property])) {
        throw new Error("Error: 'val' must be of type: " + typeof(objectClone[property]));
    } else {
        objectClone[property] = val;
    }
    return objectClone;
}

function changeImmutableMapProperty(obj, property, value) {
    var map1 = Immutable.Map(obj);
    if (typeof(property) === "string" && typeof(obj[property]) === typeof(value)) {
        var map2 = map1.set(property, value);
        console.log("Updated property '" +
            property.toString() +
            "' from " +
            map1.get(property) +
            " to " +
            map2.get(property));
        return map2;
    } else {
        console.log("WARNING: Either property or value are of incorrect type to perform change. State Object remains the same." +
            "Ensure property is a string and value is correct type.");
        return map1;
    }

}

function fadeInByID(id) {
    var $id = $("id");
    $id.fadeIn(500,function() {
        console.log("element of ID: "+ id + " faded in if hidden...");
    });
}
class PlayerStat extends React.Component {
    render() {
        this.categoryBlockID = "category" + this.props.category;
        return (
            <div id={this.categoryBlockID}>
                <div className="playerCategory">{this.props.category}</div>
                <div className="playerCategoryValue" style={this.props.playerStatStyle}>{this.props.categoryValue}</div>
            </div>);
    }
}

class PlayerProfile extends React.Component {
    constructor() {
        super();
        const numCategories = 13;
        this.state = {
            sampleData: getStateFromDotNetModel(data),
            playerStatStyle: {
                opacity: 0.0
            }
        }
    }
    handleShowAllClick() {
        //create clone of player style to preserve immutability
        // const newPlayerStatStyle = changeImmutableMapProperty(this.state.playerStatStyle, "opacity", 1.0);
        // react update is technically deprecated.
        const newPlayerStatStyle = React.addons.update(this.state.playerStatStyle,
        {
            opacity:{$set: 1.0}
        });
        this.setState(
        {
            playerStatStyle: newPlayerStatStyle
        });
 
    }

    isFilteredNamingCategory(category) {
        if (category.toString() === "Id" || category.toString() === "FirstName" || category.toString() === "LastName") {
            return true;
        } else {
            return false;
        }
    }
    renderPlayerStatList() {
        const categories = Object.keys(this.state.sampleData);
        var categoriesFiltered = categories.filter((category) =>!this.isFilteredNamingCategory(category));
        var categoriesMapped = categoriesFiltered.map((category) =>
         <li id={"statList"+category.toString()} key={category.toString() }>
            <PlayerStat categoryValue={this.state.sampleData[category]} category={category} playerStatStyle={this.state.playerStatStyle}></PlayerStat>
         </li>);
        return categoriesMapped;

    }
    render() {
        return (
            <div className="playerProfile">
            <button onClick={() =>this.handleShowAllClick()}>Show All</button>
            <ul>
                {this.renderPlayerStatList()}
            </ul>
            </div>
    );
    }
}

const FlatButtonExampleSimple = () => (
          <div>
            <FlatButton label="Default" />
            <FlatButton label="Primary" primary={true} />
            <FlatButton label="Secondary" secondary={true} />
            <FlatButton label="Disabled" disabled={true} />
          </div>
        );


ReactDOM.render(
    <PlayerProfile/>,
    document.getElementById('playerReactComp') 
    );

/*ReactDOM.render(
    <FlatButtonExampleSimple/>,
    document.getElementById('playerReactComp'));*/